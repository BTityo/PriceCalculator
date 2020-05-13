namespace PriceCalculator.Windows.ViewModels
{
    public class MaterialViewModel : BaseViewModel
    {
        private string name;
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

        private decimal twoCM;
        public decimal TwoCM
        {
            get { return twoCM; }
            set
            {
                if (twoCM != value)
                {
                    twoCM = value;
                    OnPropertyChanged("TwoCM");
                }
            }
        }

        private decimal threeCM;
        public decimal ThreeCM
        {
            get { return threeCM; }
            set
            {
                if (threeCM != value)
                {
                    threeCM = value;
                    OnPropertyChanged("ThreeCM");
                }
            }
        }

        private decimal fiveCM;
        public decimal FiveCM
        {
            get { return fiveCM; }
            set
            {
                if (fiveCM != value)
                {
                    fiveCM = value;
                    OnPropertyChanged("FiveCM");
                }
            }
        }

        private decimal eightCM;
        public decimal EightCM
        {
            get { return eightCM; }
            set
            {
                if (eightCM != value)
                {
                    eightCM = value;
                    OnPropertyChanged("EightCM");
                }
            }
        }
        private decimal nineCM;
        public decimal NineCM
        {
            get { return nineCM; }
            set
            {
                if (nineCM != value)
                {
                    nineCM = value;
                    OnPropertyChanged("NineCM");
                }
            }
        }

        private decimal tenCM;
        public decimal TenCM
        {
            get { return tenCM; }
            set
            {
                if (tenCM != value)
                {
                    tenCM = value;
                    OnPropertyChanged("TenCM");
                }
            }
        }
    }
}
