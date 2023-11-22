using CR3JW9_HFT_2023241.Logic;
using CR3JW9_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CR3JW9_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        IComputerLogic logic;
        public ComputerController(IComputerLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Computer> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Computer Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Computer value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Computer value)
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
