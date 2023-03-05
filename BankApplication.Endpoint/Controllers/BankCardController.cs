using BankApplication.Logic;
using BankApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BankApplication.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BankCardController : ControllerBase
    {
        IBankCardLogic bankCardLogic;

        public BankCardController(IBankCardLogic cardLogic)
        {
            this.bankCardLogic = cardLogic;
        }

        [HttpGet] 
        public IEnumerable<BankCard> ReadAll()
        {
            return this.bankCardLogic.ReadAll();
        }

        [HttpGet("{id}")]
        public BankCard Read(int id)
        {
            return this.bankCardLogic.Read(id);
        }
        [HttpPost] 
        public void Create([FromBody] BankCard cardToCreate)
        {
            this.bankCardLogic.Create(cardToCreate);
        }
        [HttpPut]
        public void Update([FromBody] BankCard value)
        {
            this.bankCardLogic.Update(value);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.bankCardLogic.Delete(id);
        }
    }
}
