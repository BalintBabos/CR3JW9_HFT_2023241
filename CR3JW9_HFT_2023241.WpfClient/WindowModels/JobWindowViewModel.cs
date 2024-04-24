using CR3JW9_HFT_2023241.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace CR3JW9_HFT_2023241.WpfClient.WindowModels
{
    public class JobWindowViewModel : ObservableRecipient
    {
        public bool IsSomethingSelected { get; set; } = false;
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
                        Salary = value.Salary
                    };

                    IsSomethingSelected = true;
                    OnPropertyChanged();
                }
                else
                {
                    selectedJob = new Job();
                    IsSomethingSelected = false;
                }
                (DeleteJobCommand as RelayCommand)?.NotifyCanExecuteChanged();
                (UpdateJobCommand as RelayCommand)?.NotifyCanExecuteChanged();
            }
        }

        public ICommand CreateJobCommand { get; set; }
        public ICommand DeleteJobCommand { get; set; }
        public ICommand UpdateJobCommand { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public JobWindowViewModel()
        {

        }
        public JobWindowViewModel(RestCollection<Job> jobs)
        {
            if (!IsInDesignMode)
            {
                Jobs = jobs;

                CreateJobCommand = new RelayCommand(
                    () => Jobs.Add(new Job()
                    {
                        //JobID = SelectedJob.JobID,
                        JobName = SelectedJob.JobName,
                        JobLocation = SelectedJob.JobLocation,
                        Salary = SelectedJob.Salary
                    }));

                DeleteJobCommand = new RelayCommand(
                    async () =>
                    {
                        await Jobs.Delete(SelectedJob.JobID);
                        IsSomethingSelected = false;
                    },
                    () => IsSomethingSelected == true
                    );

                UpdateJobCommand = new RelayCommand(
                    () =>
                    {
                        Jobs.Update(SelectedJob);
                    },
                    () => IsSomethingSelected == true
                    );
            }
        }
    }
}
