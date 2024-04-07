using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using CR3JW9_HFT_2023241.WpfClient.Services;
using CR3JW9_HFT_2023241.Models;

namespace CR3JW9_HFT_2023241.WpfClient.WindowModels
{
    class MainWindowViewModel : ObservableRecipient
    {
        IComputerService computerService;

        public RestCollection<Computer> computers { get; set; }

        public ICommand GetComputersCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                computers = new RestCollection<Computer>("http://localhost:59537/", "Computer", "hub");


                computerService = Ioc.Default.GetRequiredService<IComputerService>();

                GetComputersCommand = new RelayCommand(
                    () => computerService.Open(computers),
                    () => true
                    );
            }
        }

    }
}
