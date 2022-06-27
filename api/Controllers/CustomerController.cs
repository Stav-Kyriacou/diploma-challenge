using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.AspNetCore.Cors;
using api.Handlers;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        CustomerHandler dbHandler = new CustomerHandler();

        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("/customers")]
        public IEnumerable<Customer> Get()
        {
            return dbHandler.GetAllCustomers();
        }
    }
}