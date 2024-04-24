using CR3JW9_HFT_2023241.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace CR3JW9_HFT_2023241.WpfClient.WindowModels
{
    public class ComputerWindowViewModel : ObservableRecipient
    {
        public bool IsSomethingSelected { get; set; } = false;
        public RestCollection<Computer> Computers { get; set; }
        public RestCollection<Person> People { get; set; }
        public RestCollection<Job> Jobs { get; set; }

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
        public ComputerWindowViewModel(RestCollection<Computer> computers, RestCollection<Person> people, RestCollection<Job> jobs)
        {
            if (!IsInDesignMode)
            {
                Computers = computers;
                People = people;
                Jobs = jobs;

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
                    async () =>
                    {
                        await Computers.Delete(SelectedComputer.ComputerID);
                        await People.Refresh();
                        await Jobs.Refresh();
                        IsSomethingSelected = false;
                    },
                    () => IsSomethingSelected == true
                    );

                UpdateComputerCommand = new RelayCommand(
                    () => Computers.Update(SelectedComputer),
                    () => IsSomethingSelected == true
                    );
            }
        }
    }
}
