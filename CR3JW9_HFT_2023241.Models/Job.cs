using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR3JW9_HFT_2023241.Models
{
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobID { get; set; }
        public string JobName { get; set; }
        public string JobLocation { get; set; }
        public int Salary { get; set; }
    }
}
