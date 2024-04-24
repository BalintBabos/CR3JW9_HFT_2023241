using CR3JW9_HFT_2023241.Models;
using CR3JW9_HFT_2023241.WpfClient.WindowModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR3JW9_HFT_2023241.WpfClient.Services
{
    internal class PersonViaWindow : IPersonService
    {
        public void Open(RestCollection<Person> people, RestCollection<Job> jobs)
        {
            new PersonWindow(people, jobs).Show();
        }
    }
}
