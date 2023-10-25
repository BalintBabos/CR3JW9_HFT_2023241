using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR3JW9_HFT_2023241.Models
{
    public class Computer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComputerID { get; set; }
        public int RAMAmount { get; set; }
        public DateTime DateOfAssembly { get; set; }
        public string CPUManufacturer { get; set; }
        public string GPUManufacturer { get; set; }
        public string CPUModel { get; set; }
        public string GPUModel { get; set; }
    }
}
