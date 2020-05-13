namespace PriceCalculator.Windows.ViewModels
{
    public class PieceViewModel : BaseViewModel
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

        private byte value;
        public byte Value
        {
            get { return value; }
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    OnPropertyChanged("Value");
                }
            }
        }
    }
}
