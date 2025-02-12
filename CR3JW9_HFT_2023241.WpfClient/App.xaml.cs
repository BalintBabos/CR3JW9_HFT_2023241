﻿using CommunityToolkit.Mvvm.DependencyInjection;
using CR3JW9_HFT_2023241.WpfClient.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CR3JW9_HFT_2023241.WpfClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(
               new ServiceCollection()
                   .AddSingleton<IComputerService, ComputerViaWindow>()
                   .AddSingleton<IJobService, JobViaWindow>()
                   .AddSingleton<IPersonService, PersonViaWindow>()
                   .BuildServiceProvider()
                   );
        }
    }
}
