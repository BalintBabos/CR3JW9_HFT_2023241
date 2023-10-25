using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR3JW9_HFT_2023241.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonID { get; set; }

        public int JobID {  get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime WorksSince { get; set; }
    }
}
