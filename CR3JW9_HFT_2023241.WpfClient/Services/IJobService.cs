using CR3JW9_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR3JW9_HFT_2023241.WpfClient.Services
{
    interface IJobService
    {
        public void Open(RestCollection<Job> jobs);
    }
}
