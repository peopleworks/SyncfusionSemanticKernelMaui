using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Syncfusion.Maui.Core.Hosting;
using SyncfusionSemanticKernelMaui.Models;
using SyncfusionSemanticKernelMaui.Services;
using SyncfusionSemanticKernelMaui.ViewModels;

namespace SyncfusionSemanticKernelMaui
{
    public static class MauiProgram
    {
        public static IServiceProvider Services { get; private set; }
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.ConfigureSyncfusionCore();
            builder.Services.AddScoped<IAssistantService,AssistantService>();
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<MainPage>();
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("SyncfusionSemanticKernelMaui.Properties.AppSettings.json");

            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();
            builder.Configuration.AddConfiguration(config);
            var aiSettings =  builder.Configuration.GetSection("AI").Get<AISettings>();
            builder.Services.AddSingleton<AISettings>((p)=> aiSettings??new AISettings());
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            var build = builder.Build();
            Services = build.Services;
            return build;
        }
    }
}
