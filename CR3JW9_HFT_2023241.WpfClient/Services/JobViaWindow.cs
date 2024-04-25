using CR3JW9_HFT_2023241.Models;
using CR3JW9_HFT_2023241.WpfClient.WindowModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR3JW9_HFT_2023241.WpfClient.Services
{
    internal class JobViaWindow : IJobService
    {
        public void Open(RestCollection<Job> jobs, RestCollection<Person> people, RestCollection<Computer> computers)
        {
            new JobWindow(jobs, people, computers).Show();
        }
    }
}
