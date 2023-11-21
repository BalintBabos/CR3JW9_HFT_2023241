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
        public Person(int personID, int jobID, string name, int age, DateTime birthDate, DateTime worksSince)
        {
            PersonID = personID;
            JobID = jobID;
            Name = name;
            Age = age;
            BirthDate = birthDate;
            WorksSince = worksSince;
        }

        public Person()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonID { get; set; }
        public int JobID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime WorksSince { get; set; }
        public virtual ICollection<Computer> Computers { get; set; }
        public virtual Job Job { get; set; }

        public override string ToString()
        {
            return $"{PersonID} {JobID} {Name} {Age} {BirthDate} {WorksSince}";
        }
    }
}
