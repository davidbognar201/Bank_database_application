using BankApplication.Logic;
using BankApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Net.Http;

namespace BankApplication.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerLogic customerLogic;

        public CustomerController(ICustomerLogic custLogic)
        {
            this.customerLogic = custLogic;
        }

        [HttpGet] 
        public IEnumerable<Customer> ReadAll()
        {
            return this.customerLogic.ReadAll();
        }

        [HttpGet("{id}")]
        public Customer Read(int id)
        {
            return this.customerLogic.Read(id);
        }
        [HttpPost] 
        public void Create([FromBody] Customer custToCreate)
        {

            this.customerLogic.Create(custToCreate);

        }
        [HttpPut]
        public void Update([FromBody] Customer value)
        {
            this.customerLogic.Update(value);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.customerLogic.Delete(id);
        }
    }
}
