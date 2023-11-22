using CR3JW9_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR3JW9_HFT_2023241.Repository.ModelRepositories
{
    public class PersonRepository : Repository<Person>, IRepository<Person>
    {
        public PersonRepository(WorkDbContext ctx) : base(ctx)
        {
        }

        public override Person Read(int id)
        {
            return ctx.Persons.FirstOrDefault(t => t.PersonID == id);
        }

        public override void Update(Person item)
        {
            var old = Read(item.PersonID);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
