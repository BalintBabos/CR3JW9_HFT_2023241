using CR3JW9_HFT_2023241.Models;
using CR3JW9_HFT_2023241.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR3JW9_HFT_2023241.Logic
{
    public class ComputerLogic : IComputerLogic
    {
        IRepository<Computer> repo;

        public ComputerLogic(IRepository<Computer> repo)
        {
            this.repo = repo;
        }

        public void Create(Computer item)
        {
            repo.Create(item);
        }

        public void Delete(int id)
        {
            var computer = repo.Read(id);
            if(computer == null)
            {
                throw new ArgumentException();
            }
            repo.Delete(id);
        }

        public Computer Read(int id)
        {
            var computer = repo.Read(id);
            if(computer == null)
            {
                throw new ArgumentException();
            }
            return repo.Read(id);
        }

        public IQueryable<Computer> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Computer item)
        {
            var computer = item;
            if(item == null)
            {
                throw new ArgumentException();
            }
            repo.Update(item);
        }

        // non-cruds
        public int? GetNumberOfFastComputers() // has GPU & RAM >16
        {
            var result = repo.ReadAll().Where(c => c.RAMAmount >= 16 && !string.IsNullOrEmpty(c.GPUModel)).Count();
            return result;
        }

        public Person GetOwnerOfComputerByComputerID(int computerID)
        {
            var result = repo.ReadAll()
        .Where(c => c.ComputerID == computerID)
        .Select(c => c.Person)
        .FirstOrDefault();
            return result;
        }
    }
}
