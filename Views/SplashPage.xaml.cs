using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyncfusionSemanticKernelMaui.ViewModels;

namespace SyncfusionSemanticKernelMaui.Views;

public partial class SplashPage : ContentPage
{
    public SplashPage()
    {
        InitializeComponent();
        Continue();
    }

   async void   Continue()
    {

        await Task.Delay(2000);
        var mainPage = new MainPage();
        mainPage.BindingContext =MauiProgram.Services.GetService(typeof(MainViewModel)) as MainViewModel;
        Application.Current.MainPage = new NavigationPage(mainPage);
    }
}