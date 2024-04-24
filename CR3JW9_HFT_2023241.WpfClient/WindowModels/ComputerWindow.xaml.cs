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
    /// <summary>
    /// Interaction logic for ComputerWindow.xaml
    /// </summary>
    public partial class ComputerWindow : Window
    {
        public ComputerWindow(RestCollection<Computer> computers, RestCollection<Person> people, RestCollection<Job> jobs)
        {
            DataContext = new ComputerWindowViewModel(computers, people, jobs);
            InitializeComponent();
        }
    }
}
