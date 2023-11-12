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
        public Computer(int computerID, int rAMAmount, DateTime dateOfAssembly, string cPUManufacturer, string gPUManufacturer, string cPUModel, string gPUModel)
        {
            ComputerID = computerID;
            RAMAmount = rAMAmount;
            DateOfAssembly = dateOfAssembly;
            CPUManufacturer = cPUManufacturer;
            GPUManufacturer = gPUManufacturer;
            CPUModel = cPUModel;
            GPUModel = gPUModel;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComputerID { get; set; }
        public int RAMAmount { get; set; }
        public DateTime DateOfAssembly { get; set; }
        public string CPUManufacturer { get; set; }
        public string GPUManufacturer { get; set; }
        public string CPUModel { get; set; }
        public string GPUModel { get; set; }


        public override string ToString()
        {
            return $"{ComputerID} {RAMAmount} {DateOfAssembly} {CPUManufacturer} {GPUManufacturer} {CPUModel} {GPUModel}";
        }
    }
}
