using CR3JW9_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR3JW9_HFT_2023241.Repository.ModelRepositories
{
    public class ComputerRepository : Repository<Computer>, IRepository<Computer>
    {
        public ComputerRepository(WorkDbContext ctx) : base(ctx)
        {
        }

        public override Computer Read(int id)
        {
            return ctx.Computers.FirstOrDefault(t => t.ComputerID == id);
        }

        public override void Update(Computer item)
        {
            var old = Read(item.ComputerID);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
