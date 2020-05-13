using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;
using System.Windows.Media;

namespace PriceCalculator.Windows.Views.Window
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            AppearanceManager.Current.AccentColor = Colors.DarkGreen;
            InitializeComponent();
        }
    }
}
