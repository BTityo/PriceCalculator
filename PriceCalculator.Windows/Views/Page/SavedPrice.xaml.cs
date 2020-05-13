using PriceCalculator.BLL.Constants;
using PriceCalculator.BLL.Service;
using PriceCalculator.Windows.ViewModels;
using PriceCalculator.Windows.ViewModels.Maps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PriceCalculator.Windows.Views.Page
{
    /// <summary>
    /// Interaction logic for SavedPrice.xaml
    /// </summary>
    public partial class SavedPrice : UserControl
    {
        // Services
        private readonly CalculationService calculationService;
        private readonly BaseCalculationService baseCalculationService;
        // ViewModels
        private ObservableCollection<BaseCalculationViewModel> baseCalculationViewModels;
        private ObservableCollection<CalculationViewModel> calculationViewModels;
        private BaseCalculationViewModel selectedBaseCalculation;
        private CalculationViewModel selectedCalculation;

        public SavedPrice()
        {
            // Initialize services
            calculationService = new CalculationService(Constants.LocalDBPath);
            baseCalculationService = new BaseCalculationService(Constants.LocalDBPath);
            // Initialize viewmodels
            selectedBaseCalculation = new BaseCalculationViewModel();
            selectedCalculation = new CalculationViewModel();

            setViewModels();
            InitializeComponent();
            this.stackPanelBaseCalculation.DataContext = baseCalculationViewModels;
        }

        private async void setViewModels()
        {
            baseCalculationViewModels = BaseCalculationMap.MapToViewModelList(await baseCalculationService.GetBaseCalculationsAsync());
            selectedBaseCalculation = baseCalculationViewModels[0];
        }

        private async void comboBoxBaseCalculation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get BaseCalculation
            BaseCalculationViewModel baseCalculation = ((sender as ComboBox).SelectedItem as BaseCalculationViewModel);
            // Get Calculations by Basecalculation
            calculationViewModels = await CalculationMap.MapToViewModelList(await calculationService.GetCalculationsByBaseCalculationIdAsync(baseCalculation.Id));
            baseCalculation.CalculationViewModels = calculationViewModels;
            // Set SelectedBaseCalculation
            selectedBaseCalculation = baseCalculation;
            // Set bindings
            stackPanelPrices.DataContext = selectedBaseCalculation;
            dataGridCalculations.ItemsSource = calculationViewModels;
        }

        // Delete all calculation
        private void buttonDeleteAllCalculation_Click(object sender, RoutedEventArgs e)
        {

        }

        // Delete selected calculation
        private void buttonDeleteCalculation_Click(object sender, RoutedEventArgs e)
        {

        }

        // Add a new calculation
        private void buttonAddToCalculation_Click(object sender, RoutedEventArgs e)
        {

        }

        // Save Calculations
        private void buttonSaveCalculation_Click(object sender, RoutedEventArgs e)
        {

        }

        // Print selected BaseCalculation
        private void buttonPrintCalculation_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
