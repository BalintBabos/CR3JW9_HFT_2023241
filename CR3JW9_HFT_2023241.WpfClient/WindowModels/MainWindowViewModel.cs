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
        IJobService jobService;
        IPersonService personService;

        public RestCollection<Computer> computers { get; set; }
        public RestCollection<Job> jobs { get; set; }
        public RestCollection<Person> people { get; set; }

        public ICommand GetComputersCommand { get; set; }
        public ICommand GetJobsCommand { get; set; }
        public ICommand GetPeopleCommand { get; set; }

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
                jobs = new RestCollection<Job>("http://localhost:59537/", "Job", "hub");
                people = new RestCollection<Person>("http://localhost:59537/", "Person", "hub");


                computerService = Ioc.Default.GetRequiredService<IComputerService>();
                jobService = Ioc.Default.GetRequiredService<IJobService>();
                personService = Ioc.Default.GetRequiredService<IPersonService>();

                GetComputersCommand = new RelayCommand(
                    () => computerService.Open(computers),
                    () => true
                    );
                GetJobsCommand = new RelayCommand(
                    () => jobService.Open(jobs),
                    () => true
                    );
                GetPeopleCommand = new RelayCommand(
                    () => personService.Open(people),
                    () => true
                    );
            }
        }
    }
}
