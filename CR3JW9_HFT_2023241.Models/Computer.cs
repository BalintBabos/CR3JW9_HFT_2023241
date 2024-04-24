using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CR3JW9_HFT_2023241.Models
{
    public class Computer
    {

        public Computer(int computerID, int personID, int rAMAmount, DateTime dateOfAssembly, string cPUManufacturer, string gPUManufacturer, string cPUModel, string gPUModel)
        {
            ComputerID = computerID;
            PersonID = personID;
            RAMAmount = rAMAmount;
            DateOfAssembly = dateOfAssembly;
            CPUManufacturer = cPUManufacturer;
            GPUManufacturer = gPUManufacturer;
            CPUModel = cPUModel;
            GPUModel = gPUModel;
        }

        public Computer()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComputerID { get; set; }
        public int PersonID { get; set; }
        public int RAMAmount { get; set; }
        public DateTime DateOfAssembly { get; set; }
        public string CPUManufacturer { get; set; }
        public string GPUManufacturer { get; set; }
        public string CPUModel { get; set; }
        public string GPUModel { get; set; }

        [JsonIgnore]
        public virtual Person Person { get; set; }

        public override string ToString()
        {
            return $"{ComputerID} {PersonID} {RAMAmount} {DateOfAssembly} {CPUManufacturer} {GPUManufacturer} {CPUModel} {GPUModel}";
        }

        public override bool Equals(object obj)
        {
            return obj is Computer computer &&
                   ComputerID == computer.ComputerID &&
                   PersonID == computer.PersonID &&
                   RAMAmount == computer.RAMAmount &&
                   DateOfAssembly == computer.DateOfAssembly &&
                   CPUManufacturer == computer.CPUManufacturer &&
                   GPUManufacturer == computer.GPUManufacturer &&
                   CPUModel == computer.CPUModel &&
                   GPUModel == computer.GPUModel;
        }
    }
}
