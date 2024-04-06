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
using System.Security.Cryptography;

namespace CR3JW9_HFT_2023241.WpfClient.WindowModels
{
    public class JobWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public RestCollection<Job> Jobs { get; set; }

        private Job selectedJob;

        public Job SelectedJob
        {
            get { return selectedJob; }
            set
            {
                if (value != null)
                {
                    selectedJob = new Job()
                    {
                        JobID = value.JobID,
                        JobName = value.JobName,
                        JobLocation = value.JobLocation,
                        Salary = value.Salary,
                    };
                    OnPropertyChanged();
                    (DeleteJobCommand as RelayCommand).NotifyCanExecuteChanged();
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


        public ICommand CreateJobCommand { get; set; }
        public ICommand DeleteJobCommand { get; set; }
        public ICommand UpdateJobCommand { get; set; }

        public JobWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Jobs = new RestCollection<Job>("http://localhost:59537/", "Job", "hub");
                CreateJobCommand = new RelayCommand(() =>
                {
                    Jobs.Add(new Job()
                    {
                        JobName = "null",
                        Salary = 0
                    });
                });

                UpdateJobCommand = new RelayCommand(() =>
                {

                    Jobs.Update(SelectedJob);


                });

                DeleteJobCommand = new RelayCommand(() =>
                {
                    Jobs.Delete(SelectedJob.JobID);
                },
                () =>
                {
                    return SelectedJob != null;
                });
                SelectedJob = new Job();
            }
        }
    }
}
