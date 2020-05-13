using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace PriceCalculator.Windows.ViewModels
{
    public class BaseCalculationViewModel : BaseViewModel, IDataErrorInfo
    {
        public BaseCalculationViewModel()
        {
            name = "";
            withoutTaxSum = 0;
            withTaxSum = 0;
            calculationViewModel = new CalculationViewModel();
            calculationViewModels = new ObservableCollection<CalculationViewModel>();
        }

        private string name;
        /// <summary>
        /// Name of the Calculation
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        /// <summary>
        /// Already added prices of calculations without tax (net price)
        /// </summary>
        private decimal withoutTaxSum;
        public decimal WithoutTaxSum
        {
            get
            {
                withoutTaxSum = calculationViewModels.Select(c => c.CalculatedPriceNet).Sum();
                return withoutTaxSum;
            }
            set
            {
                if (withoutTaxSum != value)
                {
                    withoutTaxSum = value;
                    OnPropertyChanged("WithoutTaxSum");
                }
            }
        }

        private decimal withTaxSum;
        /// <summary>
        /// Already added prices of calculations with tax (gross price)
        /// </summary>
        public decimal WithTaxSum
        {
            get
            {
                withTaxSum = withoutTaxSum * (decimal)1.27;
                return withTaxSum;
            }
            set
            {
                if (withTaxSum != value)
                {
                    withTaxSum = value;
                    OnPropertyChanged("WithTaxSum");
                }
            }
        }

        private CalculationViewModel calculationViewModel;
        public CalculationViewModel CalculationViewModel
        {
            get { return calculationViewModel; }
            set
            {
                if (calculationViewModel != value)
                {
                    calculationViewModel = value;
                    OnPropertyChanged("CalculationViewModel");
                }
            }
        }

        private ObservableCollection<CalculationViewModel> calculationViewModels;
        public ObservableCollection<CalculationViewModel> CalculationViewModels
        {
            get
            {
                return calculationViewModels;
            }
            set
            {
                if (calculationViewModels != value)
                {
                    calculationViewModels = value;
                    OnPropertyChanged("CalculationViewModels");
                }
            }
        }

        // Validation
        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Name")
                {
                    return string.IsNullOrEmpty(this.name) ? "Nem lehet üres" : null;
                }
                if (columnName == "WithoutTaxSum")
                {
                    return (this.withoutTaxSum <= 0) ? "Nagyobbnak kell lennie, mint 0" : null;
                }
                if (columnName == "WithTaxSum")
                {
                    return (this.withTaxSum <= 0) ? "Nagyobbnak kell lennie, mint 0" : null;
                }
                return null;
            }
        }
    }
}
