using CR3JW9_HFT_2023241.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace CR3JW9_HFT_2023241.WpfClient.WindowModels
{
    public class PersonWindowViewModel : ObservableRecipient
    {
        public bool IsSomethingSelected { get; set; } = false;
        public RestCollection<Person> People { get; set; }
        public RestCollection<Job> Jobs { get; set; }

        private Person selectedPerson;
        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                if (value != null)
                {
                    selectedPerson = new Person()
                    {
                        PersonID = value.PersonID,
                        JobID = value.JobID,
                        Name = value.Name,
                        Age = value.Age,
                        BirthDate = value.BirthDate,
                        WorksSince = value.WorksSince
                    };

                    IsSomethingSelected = true;
                    OnPropertyChanged();
                }
                else
                {
                    selectedPerson = new Person();
                    IsSomethingSelected = false;
                }
                (DeletePersonCommand as RelayCommand)?.NotifyCanExecuteChanged();
                (UpdatePersonCommand as RelayCommand)?.NotifyCanExecuteChanged();
            }
        }

        public ICommand CreatePersonCommand { get; set; }
        public ICommand DeletePersonCommand { get; set; }
        public ICommand UpdatePersonCommand { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public PersonWindowViewModel()
        {

        }
        public PersonWindowViewModel(RestCollection<Person> people, RestCollection<Job> jobs)
        {
            if (!IsInDesignMode)
            {
                People = people;
                Jobs = jobs;

                CreatePersonCommand = new RelayCommand(
                    () => People.Add(new Person()
                    {
                        //PersonID = SelectedPerson.PersonID,
                        //JobID = SelectedPerson.JobID,
                        Name = SelectedPerson.Name,
                        Age = SelectedPerson.Age,
                        BirthDate = SelectedPerson.BirthDate,
                        WorksSince = SelectedPerson.WorksSince
                    }));

                DeletePersonCommand = new RelayCommand(
                    async () =>
                    {
                        await People.Delete(SelectedPerson.PersonID);
                        await Jobs.Refresh();
                        IsSomethingSelected = false;
                    },
                    () => IsSomethingSelected == true
                    );

                UpdatePersonCommand = new RelayCommand(
                    () => People.Update(SelectedPerson),
                    () => IsSomethingSelected == true
                    );
            }
        }
    }
}
