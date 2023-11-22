using CR3JW9_HFT_2023241.Logic;
using CR3JW9_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CR3JW9_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IPersonLogic logic;
        public PersonController(IPersonLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Person> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Person Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Person value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Person value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
