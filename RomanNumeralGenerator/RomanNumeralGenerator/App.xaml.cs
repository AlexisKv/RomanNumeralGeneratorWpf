using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RomanNumeral.Core.Models;
using RomanNumeral.Core.Services;
using RomanNumeral.Data;
using RomanNumeral.Services;

namespace RomanNumeralGenerator
{
    
    public partial class App : Application
    {
        public static IHost? AppHost { get; set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<IRomanNumeralGenerator, GeneratorServices>();
                        
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();
            
            var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            startupForm.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }
    }
    
    
}
