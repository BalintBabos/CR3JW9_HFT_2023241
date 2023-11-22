using CR3JW9_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CR3JW9_HFT_2023241.Logic
{
    public interface IComputerLogic
    {
        void Create(Computer item);
        void Delete(int id);
        Computer Read(int id);
        IQueryable<Computer> ReadAll();
        void Update(Computer item);
        public int? GetNumberOfFastComputers();
        public string? GetOwnerOfComputerByComputerID(int computerID);
    }
}
