using FirstFloor.ModernUI.Windows.Controls;
using PriceCalculator.BLL.Constants;
using PriceCalculator.BLL.Service;
using PriceCalculator.Windows.Services;
using PriceCalculator.Windows.ViewModels;
using PriceCalculator.Windows.ViewModels.Maps;
using System;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PriceCalculator.Windows.Views.Page
{
    /// <summary>
    /// Interaction logic for PriceCalculator.xaml
    /// </summary>
    public partial class PriceCalculator : UserControl
    {
        // Services
        private readonly CalculationService calculationService;
        private readonly BaseCalculationService baseCalculationService;
        // ViewModels
        private BaseCalculationViewModel baseCalculationViewModel;

        private CalculationViewModel selectedCalculation;

        public PriceCalculator()
        {
            // Initialize services
            calculationService = new CalculationService(Constants.LocalDBPath);
            baseCalculationService = new BaseCalculationService(Constants.LocalDBPath);
            // Initialize viewmodels
            baseCalculationViewModel = new BaseCalculationViewModel();

            InitializeComponent();

            ((INotifyCollectionChanged)listBoxCalculations.Items).CollectionChanged += listBoxCalculations_CollectionChanged; ;
            this.DataContext = baseCalculationViewModel.CalculationViewModel;
            this.stackPanelCalculations.DataContext = baseCalculationViewModel.CalculationViewModels;
            this.stackPanelResult.DataContext = baseCalculationViewModel;
            this.stackPanelPrintSave.DataContext = baseCalculationViewModel;
        }

        // Event when CalculationViewModels collection changed
        private void listBoxCalculations_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Hide delete buttons of calculations if no item in listbox else show buttons
            if (listBoxCalculations.Items.Count > 0)
            {
                stackPanelDeleteCalculation.Visibility = Visibility.Visible;
            }
            else
            {
                stackPanelDeleteCalculation.Visibility = Visibility.Collapsed;
            }

            // Scroll to the new item
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                listBoxCalculations.ScrollIntoView(e.NewItems[0]);
                textBoxWithoutTax.Text = baseCalculationViewModel.WithoutTaxSum.ToString("c0");
                textBoxWithTax.Text = baseCalculationViewModel.WithTaxSum.ToString("c0");
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Reset)
            {
                textBoxWithoutTax.Text = baseCalculationViewModel.WithoutTaxSum.ToString("c0");
                textBoxWithTax.Text = baseCalculationViewModel.WithTaxSum.ToString("c0");
            }
        }

        // Delete all calculations
        private void buttonDeleteAllCalculation_Click(object sender, RoutedEventArgs e)
        {
            baseCalculationViewModel.CalculationViewModels.Clear();
            // Create a new viewmodel for the new calculation
            baseCalculationViewModel.CalculationViewModel = new CalculationViewModel();
            this.DataContext = baseCalculationViewModel.CalculationViewModel;
        }

        // Delete selected calculation
        private void buttonDeleteCalculation_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCalculation != null && baseCalculationViewModel.CalculationViewModels != null && baseCalculationViewModel.CalculationViewModels.Count > 0)
            {
                baseCalculationViewModel.CalculationViewModels.Remove(selectedCalculation);
            }
        }

        // Print calculations
        private void buttonPrintCalculation_Click(object sender, RoutedEventArgs e)
        {
            PrintService.PrintItems(baseCalculationViewModel);
        }

        // Save calculations
        private async void buttonSaveCalculation_Click(object sender, RoutedEventArgs e)
        {
            if (baseCalculationViewModel.CalculationViewModels != null && baseCalculationViewModel.CalculationViewModels.Count > 0)
            {
                // Check BaseCalculation is already exists
                var savedBaseCalculation = await baseCalculationService.GetBaseCalculationByNameAsync(baseCalculationViewModel.Name);

                // BaseCalculation is already exists -> Update BaseCalclulation if User want
                if (savedBaseCalculation != null && savedBaseCalculation.Name == baseCalculationViewModel.Name)
                {
                    MessageBoxResult result = ModernDialog.ShowMessage("A megadott névvel '" + savedBaseCalculation.Name + "' már létezik árajánlat!\nÚj árajánlathoz adj meg egy másik nevet.\nMódosítod a meglévőt most?", "Létező árajánlat", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        try
                        {
                            savedBaseCalculation.WithoutTaxSum = baseCalculationViewModel.WithoutTaxSum;
                            savedBaseCalculation.WithTaxSum = baseCalculationViewModel.WithTaxSum;
                            await baseCalculationService.UpdateBaseCalculationAsync(savedBaseCalculation);

                            // In first delete calculations from table
                            await calculationService.DeleteCalculationsByBaseCalculationIdAsync(savedBaseCalculation.Id);
                            // Insert Calculations
                            await calculationService.InsertCalculationsAsync(CalculationMap.MapToEntityList(baseCalculationViewModel.CalculationViewModels), savedBaseCalculation);

                            ModernDialog.ShowMessage("A(z) '" + savedBaseCalculation.Name + "' árajánlat mentése sikeres", "Mentés", MessageBoxButton.OK);
                        }
                        catch (Exception ex)
                        {
                            ModernDialog.ShowMessage("Hiba az árajánlat mentésekor:\n" + ex.Message, "Mentési hiba", MessageBoxButton.OK);
                        }
                    }
                }
                // BaseCalculation does not exists -> Insert BaseCalculation
                else
                {
                    if (String.IsNullOrEmpty(baseCalculationViewModel.Name))
                    {
                        baseCalculationViewModel.Name = baseCalculationViewModel.CalculationViewModels[0].SelectedMaterial.Name + "_" + DateTime.Now;
                    }

                    try
                    {
                        // Insert BaseCalculation
                        var insertedBaseCalculation = await baseCalculationService.InsertBaseCalculationAsync(BaseCalculationMap.MapToEntity(baseCalculationViewModel));
                        // Insert Calculations
                        await calculationService.InsertCalculationsAsync(CalculationMap.MapToEntityList(baseCalculationViewModel.CalculationViewModels), insertedBaseCalculation);

                        // Set BaseCalculationViewModel after insert with new properties
                        baseCalculationViewModel.Id = insertedBaseCalculation.Id;
                        baseCalculationViewModel.InsertDate = insertedBaseCalculation.InsertDate;

                        ModernDialog.ShowMessage("A(z) '" + baseCalculationViewModel.Name + "' árajánlat mentése sikeres", "Mentés", MessageBoxButton.OK);
                    }
                    catch (Exception ex)
                    {
                        ModernDialog.ShowMessage("Hiba az új árajánlat mentésekor:\n" + ex.Message, "Mentési hiba", MessageBoxButton.OK);
                    }
                }
            }
        }

        // Add item to Calculation View
        private void buttonAddToCalculation_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxWidth.Text != "0 cm" && textBoxLength.Text != "0 cm")
            {
                CalculationViewModel tempCalculationViewModel = new CalculationViewModel();
                tempCalculationViewModel.Id = baseCalculationViewModel.CalculationViewModel.Id;
                tempCalculationViewModel.BaseCalculation = baseCalculationViewModel.CalculationViewModel.BaseCalculation;
                tempCalculationViewModel.CalculatedPriceGross = baseCalculationViewModel.CalculationViewModel.CalculatedPriceGross;
                tempCalculationViewModel.CalculatedPriceNet = baseCalculationViewModel.CalculationViewModel.CalculatedPriceNet;
                tempCalculationViewModel.Length = baseCalculationViewModel.CalculationViewModel.Length;
                tempCalculationViewModel.Width = baseCalculationViewModel.CalculationViewModel.Width;
                tempCalculationViewModel.SquareMeterPrice = baseCalculationViewModel.CalculationViewModel.SquareMeterPrice;
                tempCalculationViewModel.SelectedMaterial = baseCalculationViewModel.CalculationViewModel.SelectedMaterial;
                tempCalculationViewModel.SelectedPiece = baseCalculationViewModel.CalculationViewModel.SelectedPiece;
                tempCalculationViewModel.SelectedThickness = baseCalculationViewModel.CalculationViewModel.SelectedThickness;
                baseCalculationViewModel.CalculationViewModels.Add(tempCalculationViewModel);
            }
            else
            {
                ModernDialog.ShowMessage("'Hosszúság' és 'Szélesség' mezők kitöltése kötelező!", "Mezők kitöltése kötelező", MessageBoxButton.OK);
            }
        }

        // Select actual ListBoxItem. We can do this because of DataTemplate
        private void StackPanel_MouseLeftButtonDownUp(object sender, MouseButtonEventArgs e)
        {
            var selectedCalculationListBoxItem = ((((StackPanel)sender).TemplatedParent as ContentPresenter).TemplatedParent as ListBoxItem);
            selectedCalculationListBoxItem.IsSelected = true;
            selectedCalculation = selectedCalculationListBoxItem.Content as CalculationViewModel;
        }

        // Delete text from Length and Width TextBoxes if it got focus
        private void textBoxSize_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox actualTextBox = (sender as TextBox);
            actualTextBox.Text = "";
        }

        // Allow only numbers in Length and Widt TextBoxes
        private void textBoxSize_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void textBoxSize_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // PreviewTextInput does not control space key
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
