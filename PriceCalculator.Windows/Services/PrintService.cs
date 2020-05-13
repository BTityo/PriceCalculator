using PriceCalculator.Windows.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;

namespace PriceCalculator.Windows.Services
{
    public static class PrintService
    {
        private static string printedItems = "";

        private static void concatenateItems(BaseCalculationViewModel baseCalculation)
        {
            foreach (CalculationViewModel calculation in baseCalculation.CalculationViewModels)
            {
                printedItems += calculation.SelectedMaterial.Name + " -- ";
                printedItems += calculation.SelectedThickness.Name + "-es : ";
                printedItems += calculation.Length.ToString() + " cm | ";
                printedItems += calculation.Width.ToString() + " cm | ";
                printedItems += calculation.SelectedPiece.Name + " db | ";
                printedItems += calculation.SquareMeter.ToString() + " m2 -- ";
                printedItems += "Négyzetméter ár: " + calculation.SquareMeterPrice.ToString("c0") + " ---> ";
                printedItems += "Számolt ár: " + calculation.CalculatedPriceNet.ToString("c0") + " (nettó)";
                printedItems += " ---> Számolt ár: " + calculation.CalculatedPriceGross.ToString("c0") + " (bruttó)";
                printedItems += "\n";
            }
        }

        public static void PrintItems(BaseCalculationViewModel baseCalculation)
        {
            concatenateItems(baseCalculation);

            // Landscape orientation document
            PrintDialog printDialog = new PrintDialog();
            printDialog.PrintTicket.PageOrientation = System.Printing.PageOrientation.Landscape;
            if (printDialog.ShowDialog() != true) return;

            // Frame of document
            FixedDocument document = new FixedDocument();
            document.DocumentPaginator.PageSize = new Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight);

            // Page in document
            FixedPage page = new FixedPage();
            page.Width = document.DocumentPaginator.PageSize.Width;
            page.Height = document.DocumentPaginator.PageSize.Height;

            // Add TextBlock-s to the Page
            TextBlock date = new TextBlock();
            date.Text = DateTime.Now.ToString();
            date.FontSize = 18;
            date.Foreground = Brushes.DarkSlateBlue;
            date.Margin = new System.Windows.Thickness(50, 75, 50, 50);

            TextBlock title = new TextBlock();
            title.Text = baseCalculation.Name;
            title.FontSize = 22;
            title.Foreground = Brushes.DarkGreen;
            title.Margin = new System.Windows.Thickness(50, 120, 50, 50);

            TextBlock items = new TextBlock();
            items.Text = printedItems;
            items.FontSize = 16;
            items.Margin = new System.Windows.Thickness(50, 150, 50, 50);

            TextBlock withoutTax = new TextBlock();
            withoutTax.Text = "Áfa nélkül: " + baseCalculation.WithoutTaxSum.ToString("c0");
            withoutTax.FontSize = 18;
            withoutTax.Foreground = Brushes.DarkOrange;
            withoutTax.Margin = new System.Windows.Thickness(800, 400, 50, 50);
            withoutTax.HorizontalAlignment = HorizontalAlignment.Right;

            TextBlock withTax = new TextBlock();
            withTax.Text = "Áfás ár: " + baseCalculation.WithTaxSum.ToString("c0");
            withTax.FontSize = 20;
            withTax.Foreground = Brushes.Red;
            withTax.Margin = new System.Windows.Thickness(800, 450, 50, 50);

            page.Children.Add(date);
            page.Children.Add(title);
            page.Children.Add(items);
            page.Children.Add(withoutTax);
            page.Children.Add(withTax);

            // Add Page to the Document
            PageContent page1Content = new PageContent();
            ((IAddChild)page1Content).AddChild(page);
            document.Pages.Add(page1Content);

            // Print
            printDialog.PrintDocument(document.DocumentPaginator, baseCalculation.Name);
            printedItems = "";
        }
    }
}
