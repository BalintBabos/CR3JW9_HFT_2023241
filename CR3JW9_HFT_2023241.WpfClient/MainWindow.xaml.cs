using CR3JW9_HFT_2023241.WpfClient.WindowModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CR3JW9_HFT_2023241.WpfClient.WindowModels;

namespace CR3JW9_HFT_2023241.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ComputerWindow computerWindow;
        private JobWindow jobWindow;
        private PersonWindow personWindow;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Computer_Click(object sender, RoutedEventArgs e)
        {
            if (computerWindow == null || !computerWindow.IsVisible)
            {
                computerWindow = new ComputerWindow();
                computerWindow.Closed += ComputerWindow_Closed;
                computerWindow.Show();
            }
        }

        private void ComputerWindow_Closed(object sender, EventArgs e)
        {
            if (computerWindow != null)
            {
                computerWindow.Closed -= ComputerWindow_Closed;
                computerWindow = null;
            }
        }

        private void Job_Click(object sender, RoutedEventArgs e)
        {
            if (jobWindow == null || !jobWindow.IsVisible)
            {
                jobWindow = new JobWindow();
                jobWindow.Closed += JobWindow_Closed;
                jobWindow.Show();
            }
        }

        private void JobWindow_Closed(object sender, EventArgs e)
        {
            if (jobWindow != null)
            {
                jobWindow.Closed -= JobWindow_Closed;
                jobWindow = null;
            }
        }

        private void Person_Click(object sender, RoutedEventArgs e)
        {
            if (personWindow == null || !personWindow.IsVisible)
            {
                personWindow = new PersonWindow();
                personWindow.Closed += PersonWindow_Closed;
                personWindow.Show();
            }
        }

        private void PersonWindow_Closed(object sender, EventArgs e)
        {
            if (personWindow != null)
            {
                personWindow.Closed -= PersonWindow_Closed;
                personWindow = null;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Biztosan be szeretnéd zárni az alkalmazást?", "Megerősítés", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
