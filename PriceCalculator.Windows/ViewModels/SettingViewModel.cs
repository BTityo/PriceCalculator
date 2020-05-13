namespace PriceCalculator.Windows.ViewModels
{
    public class SettingViewModel : BaseViewModel
    {
        private bool isStartWithWindows;
        public bool IsStartWithWindows
        {
            get { return isStartWithWindows; }
            set
            {
                if (isStartWithWindows != value)
                {
                    isStartWithWindows = value;
                    OnPropertyChanged("IsStartWithWindows");
                }
            }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                if (userName != value)
                {
                    userName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }

        private string platform;
        public string Platform
        {
            get { return platform; }
            set
            {
                if (platform != value)
                {
                    platform = value;
                    OnPropertyChanged("Platform");
                }
            }
        }
    }
}
