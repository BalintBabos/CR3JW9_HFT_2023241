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
using Newtonsoft.Json.Linq;

namespace CR3JW9_HFT_2023241.WpfClient.WindowModels
{
    public class ComputerWindowViewModel : ObservableRecipient
    {

        //                    ComputerID = value.ComputerID,
        //                    PersonID = value.PersonID,
        //                    RAMAmount = value.RAMAmount,
        //                    DateOfAssembly = value.DateOfAssembly,
        //                    CPUManufacturer = value.CPUManufacturer,
        //                    GPUManufacturer = value.GPUManufacturer,
        //                    CPUModel = value.CPUModel,
        //                    GPUModel = value.GPUModel
        //private int computerID; public int ComputerID
        //{
        //    get { return computerID; }
        //    set { SetProperty(ref computerID, value); }
        //}
        //private int personID; public int PersonID
        //{
        //    get { return personID; }
        //    set { SetProperty(ref personID, value); }
        //}
        //private int ramAmount; public int RAMAmount
        //{
        //    get { return ramAmount; }
        //    set { SetProperty(ref ramAmount, value); }
        //}

        //private DateTime dateOfAssembly; public DateTime DateOfAssembly
        //{
        //    get { return dateOfAssembly; }
        //    set { SetProperty(ref dateOfAssembly, value); }
        //}
        //private string cpuManufacturer; public string CPUManufacturer
        //{
        //    get { return cpuManufacturer; }
        //    set { SetProperty(ref cpuManufacturer, value); }
        //}
        //private string gpuManufacturer; public string GPUManufacturer
        //{
        //    get { return gpuManufacturer; }
        //    set { SetProperty(ref gpuManufacturer, value); }
        //}
        //private string cpuModel; public string CPUModel
        //{
        //    get { return cpuModel; }
        //    set { SetProperty(ref cpuModel, value); }
        //}
        //private string gpuModel; public string GPUModel
        //{
        //    get { return gpuModel; }
        //    set { SetProperty(ref gpuModel, value); }
        //}

        public bool IsSomethingSelected { get; set; } = false;
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

                    IsSomethingSelected = true;
                    OnPropertyChanged();
                }
                else
                {
                    selectedComputer = new Computer();
                    IsSomethingSelected = false;
                }
                (DeleteComputerCommand as RelayCommand)?.NotifyCanExecuteChanged();
                (UpdateComputerCommand as RelayCommand)?.NotifyCanExecuteChanged();
            }
        }

        public ICommand CreateComputerCommand { get; set; }
        public ICommand DeleteComputerCommand { get; set; }
        public ICommand UpdateComputerCommand { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public ComputerWindowViewModel()
        {

        }
        public ComputerWindowViewModel(RestCollection<Computer> computers)
        {
            if (!IsInDesignMode)
            {
                Computers = computers;

                CreateComputerCommand = new RelayCommand(
                    () => Computers.Add(new Computer()
                    {
                        //ComputerID = SelectedComputer.ComputerID,
                        //PersonID = SelectedComputer.PersonID,
                        RAMAmount = SelectedComputer.RAMAmount,
                        DateOfAssembly = SelectedComputer.DateOfAssembly,
                        CPUManufacturer = SelectedComputer.CPUManufacturer,
                        GPUManufacturer = SelectedComputer.GPUManufacturer,
                        CPUModel = SelectedComputer.CPUModel,
                        GPUModel = SelectedComputer.GPUModel
                    }));

                DeleteComputerCommand = new RelayCommand(
                    () =>
                    {
                        Computers.Delete(SelectedComputer.ComputerID);
                        IsSomethingSelected = false;
                    },
                    () => IsSomethingSelected == true
                    );

                UpdateComputerCommand = new RelayCommand(
                    () =>
                    {
                        Computers.Update(SelectedComputer);
                    },
                    () => IsSomethingSelected == true
                    );
            }
        }






        //    private string errorMessage;

        //    public string ErrorMessage
        //    {
        //        get { return errorMessage; }
        //        set { SetProperty(ref errorMessage, value); }
        //    }
        //    public RestCollection<Computer> Computers { get; set; }

        //    private Computer selectedComputer;

        //    public Computer SelectedComputer
        //    {
        //        get { return selectedComputer; }
        //        set
        //        {
        //            if (value != null)
        //            {
        //                selectedComputer = new Computer()
        //                {
        //                    ComputerID = value.ComputerID,
        //                    PersonID = value.PersonID,
        //                    RAMAmount = value.RAMAmount,
        //                    DateOfAssembly = value.DateOfAssembly,
        //                    CPUManufacturer = value.CPUManufacturer,
        //                    GPUManufacturer = value.GPUManufacturer,
        //                    CPUModel = value.CPUModel,
        //                    GPUModel = value.GPUModel
        //                };
        //                OnPropertyChanged();
        //                (DeleteComputerCommand as RelayCommand).NotifyCanExecuteChanged();
        //            }
        //        }
        //    }
        //    public static bool IsInDesignMode
        //    {
        //        get
        //        {
        //            var prop = DesignerProperties.IsInDesignModeProperty;
        //            return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
        //        }
        //    }


        //    public ICommand CreateComputerCommand { get; set; }
        //    public ICommand DeleteComputerCommand { get; set; }
        //    public ICommand UpdateComputerCommand { get; set; }

        //    public ComputerWindowViewModel()
        //    {
        //        if (!IsInDesignMode)
        //        {
        //            Computers = new RestCollection<Computer>("http://localhost:59537/", "Computer", "hub");
        //            CreateComputerCommand = new RelayCommand(() =>
        //            {
        //                Computers.Add(new Computer()
        //                {

        //                    GPUModel = "none",
        //                    GPUManufacturer = "none",

        //                });
        //            });

        //            UpdateComputerCommand = new RelayCommand(() =>
        //            {

        //                Computers.Update(SelectedComputer);


        //            });

        //            DeleteComputerCommand = new RelayCommand(() =>
        //            {
        //                Computers.Delete(SelectedComputer.ComputerID);
        //            },
        //            () =>
        //            {
        //                return SelectedComputer != null;
        //            });
        //            SelectedComputer = new Computer();
        //        }
        //    }
    }
}
