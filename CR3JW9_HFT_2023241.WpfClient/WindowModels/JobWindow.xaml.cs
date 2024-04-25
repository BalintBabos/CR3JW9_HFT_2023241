using CR3JW9_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CR3JW9_HFT_2023241.WpfClient.WindowModels
{
    /// <summary>
    /// Interaction logic for JobWindow.xaml
    /// </summary>
    public partial class JobWindow : Window
    {
        public JobWindow(RestCollection<Job> jobs, RestCollection<Person> people, RestCollection<Computer> computers)
        {
            DataContext = new JobWindowViewModel(jobs, people, computers);
            InitializeComponent();
        }
    }
}
