using System.Collections.ObjectModel;

using Microsoft.Maui.Controls;
using SyncfusionSemanticKernelMaui.Models;
using SyncfusionSemanticKernelMaui.ViewModels;
using SyncfusionSemanticKernelMaui.Views;

namespace SyncfusionSemanticKernelMaui
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider
                .RegisterLicense(
                    "");

            UserAppTheme = AppTheme.Light;
            InitializeComponent();

           
            MainPage = new NavigationPage(new SplashPage());
        }
    }
}
