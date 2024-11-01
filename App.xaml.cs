using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using SyncfusionSemanticKernelMaui.Models;
using SyncfusionSemanticKernelMaui.ViewModels;

namespace SyncfusionSemanticKernelMaui
{
    public partial class App : Application
    {

        public App()
        {
                        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NDaF5cWWtCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWH9feHVURmldWEJ+X0I=");
            var mainPage = new MainPage();
            mainPage.BindingContext =MauiProgram.Services.GetService(typeof(MainViewModel)) as MainViewModel;

            InitializeComponent();

            MainPage = new NavigationPage(mainPage);
        }
    }
}
