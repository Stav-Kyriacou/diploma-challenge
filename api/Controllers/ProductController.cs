using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.AspNetCore.Cors;
using api.Handlers;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        ProductHandler dbHandler = new ProductHandler();

        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("/products")]
        public IEnumerable<Product> Get()
        {
            return dbHandler.GetAllProducts();
        }
    }
}