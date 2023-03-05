using BankApplication.Logic;
using BankApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BankApplication.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CurrentAccountController : ControllerBase
    {
        ICurrentAccountLogic accountLogic;

        public CurrentAccountController(ICurrentAccountLogic caLogic)
        {
            this.accountLogic = caLogic;
        }

        [HttpGet] 
        public IEnumerable<CurrentAccount> ReadAll()
        {
            return this.accountLogic.ReadAll();
        }

        [HttpGet("{id}")]
        public CurrentAccount Read(int id)
        {
            return this.accountLogic.Read(id);
        }
        [HttpPost] 
        public void Create([FromBody] CurrentAccount carToCreate)
        {
            this.accountLogic.Create(carToCreate);
        }
        [HttpPut]
        public void Update([FromBody] CurrentAccount value)
        {
            this.accountLogic.Update(value);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.accountLogic.Delete(id);
        }
    }
}
