using FirstFloor.ModernUI.Windows.Controls;
using Microsoft.Win32;
using PriceCalculator.BLL.Constants;
using System;
using System.Reflection;
using System.Windows;

namespace PriceCalculator.Windows.Services
{
    public static class StartupService
    {
        // Set this application to windows startup
        public static void SetAppToStartUp()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                key.SetValue(Assembly.GetExecutingAssembly().GetName().Name, Constants.ExeFile);
            }
            catch (Exception ex)
            {
                ModernDialog.ShowMessage("Nem lehet a programot az indítópulthoz adni:" + Environment.NewLine + ex.Message, "Indítópult hiba", MessageBoxButton.OK);
            }
        }

        // Remove this application from windows startup
        public static void RemoveAppFromStartUp()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                key.DeleteValue(Assembly.GetExecutingAssembly().GetName().Name, false);
            }
            catch (Exception ex)
            {
                ModernDialog.ShowMessage("Nem lehet a programot az indítópultból törölni:" + Environment.NewLine + ex.Message, "Indítópult hiba", MessageBoxButton.OK);
            }
        }
    }
}
