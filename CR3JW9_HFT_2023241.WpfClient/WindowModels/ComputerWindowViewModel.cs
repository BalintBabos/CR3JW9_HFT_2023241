using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using CR3JW9_HFT_2023241.Models;

namespace CR3JW9_HFT_2023241.WpfClient.WindowModels
{
    public class ComputerWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public RestCollection<Computer> Computers { get; set; }

        private Computer selectedComputer;

        public Computer SelectedComputer
        {
            get { return selectedComputer; }
            set
            {
                if (value != null)
                {
                    selectedComputer = new Computer()
                    {
                        ComputerID = value.ComputerID,
                        PersonID = value.PersonID,
                        RAMAmount = value.RAMAmount,
                        DateOfAssembly = value.DateOfAssembly,
                        CPUManufacturer = value.CPUManufacturer,
                        GPUManufacturer = value.GPUManufacturer,
                        CPUModel = value.CPUModel,
                        GPUModel = value.GPUModel
                    };
                    OnPropertyChanged();
                    (DeleteComputerCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public ICommand CreateComputerCommand { get; set; }
        public ICommand DeleteComputerCommand { get; set; }
        public ICommand UpdateComputerCommand { get; set; }

        public ComputerWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Computers = new RestCollection<Computer>("http://localhost:59537/", "Computer", "hub");
                CreateComputerCommand = new RelayCommand(() =>
                {
                    Computers.Add(new Computer()
                    {

                        GPUModel = "none",
                        GPUManufacturer = "none",
                       
                    });
                });

                UpdateComputerCommand = new RelayCommand(() =>
                {

                    Computers.Update(SelectedComputer);
             

                });

                DeleteComputerCommand = new RelayCommand(() =>
                {
                    Computers.Delete(SelectedComputer.ComputerID);
                },
                () =>
                {
                    return SelectedComputer != null;
                });
                SelectedComputer = new Computer();
            }
        }
    }
}
