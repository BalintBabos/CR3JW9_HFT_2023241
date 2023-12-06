using CR3JW9_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CR3JW9_HFT_2023241.Logic
{
    public interface IPersonLogic
    {
        void Create(Person item);
        void Delete(int id);
        Person Read(int id);
        IQueryable<Person> ReadAll();
        void Update(Person item);
        IEnumerable<Computer> GetCPUModelByJobID(int jobID);
    }
}
