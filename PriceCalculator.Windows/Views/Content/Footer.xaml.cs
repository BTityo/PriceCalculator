using PriceCalculator.BLL.Constants;
using PriceCalculator.BLL.Service;
using PriceCalculator.DAL.Models;
using PriceCalculator.DAL.Repository;
using PriceCalculator.Windows.Services;
using PriceCalculator.Windows.ViewModels;
using PriceCalculator.Windows.ViewModels.Maps;
using System.Windows.Controls;

namespace PriceCalculator.Windows.Views.Content
{
    /// <summary>
    /// Interaction logic for Footer.xaml
    /// </summary>
    public partial class Footer : UserControl
    {
        // Services
        private readonly SettingService settingService;
        // ViewModels
        private SettingViewModel settingViewModel;

        public Footer()
        {
            // Initialize services
            settingService = new SettingService(Constants.LocalDBPath);
            // Initialize viewmodels
            settingViewModel = new SettingViewModel();

            setViewModels();

            InitializeComponent();
            this.DataContext = settingViewModel;
        }

        private async void setViewModels()
        {
            string currentUser = LoggedInUserService.GetLoggedInUserName();
            var setting = await settingService.GetSettingByUserNameAsync(currentUser);

            // If current user is exists just use that setting
            if (setting != null)
            {
                settingViewModel = SettingMap.MapToViewModel(setting);
            }
            // If current user does not exists just insert new setting and use it
            else
            {
                setting = new Setting { UserName = currentUser, Platform = OsInfo.GetOsInfo(true), IsStartWithWindows = false };
                setting = await settingService.InsertSettingAsync(setting);
                settingViewModel = SettingMap.MapToViewModel(setting);
            }
        }

        // Save setting model
        private async void checkBoxIsStartWindows_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            bool isStartWithWindows = checkBoxIsStartWindows.IsChecked.HasValue ? checkBoxIsStartWindows.IsChecked.Value : false;
            await settingService.UpdateSettingAsync(SettingMap.MapToEntity(settingViewModel)).ContinueWith(async setting =>
            {
                Setting settingResult = await setting;
                if (settingResult != null && isStartWithWindows)
                {
                    StartupService.SetAppToStartUp();
                }
                else if (settingResult != null && !isStartWithWindows)
                {
                    StartupService.RemoveAppFromStartUp();
                }
            });
        }
    }
}
