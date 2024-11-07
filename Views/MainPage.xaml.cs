using System;
using Microsoft.Maui.Accessibility;
using Microsoft.Maui.Controls;
using SyncfusionSemanticKernelMaui.ViewModels;

namespace SyncfusionSemanticKernelMaui
{
    public partial class MainPage 
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is MainViewModel vw)
            {
               // vw.Init();
            }
        }
    }

}
