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
using System.Windows.Controls;
using System.Xml.Linq;

namespace CR3JW9_HFT_2023241.WpfClient.WindowModels
{
    public class PersonWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public RestCollection<Person> People { get; set; }

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
                    OnPropertyChanged();
                    (DeletePersonCommand as RelayCommand).NotifyCanExecuteChanged();
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


        public ICommand CreatePersonCommand { get; set; }
        public ICommand DeletePersonCommand { get; set; }
        public ICommand UpdatePersonCommand { get; set; }

        public PersonWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                People = new RestCollection<Person>("http://localhost:59537/", "Person", "hub");
                CreatePersonCommand = new RelayCommand(() =>
                {
                    People.Add(new Person()
                    {

                        Name = "none",
                        Age = 0

                    });
                });

                UpdatePersonCommand = new RelayCommand(() =>
                {

                    People.Update(SelectedPerson);


                });

                DeletePersonCommand = new RelayCommand(() =>
                {
                    People.Delete(SelectedPerson.PersonID);
                },
                () =>
                {
                    return SelectedPerson != null;
                });
                SelectedPerson = new Person();
            }
        }
    }
}
