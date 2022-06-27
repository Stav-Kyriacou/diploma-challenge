using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.AspNetCore.Cors;
using api.Handlers;
using System;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        OrderHandler dbHandler = new OrderHandler();

        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("/orders")]
        public IEnumerable<Order> Get()
        {
            return dbHandler.GetAllOrders();
        }

        /// <summary>
        /// Create a new order
        /// </summary>
        /// <param name="custID"></param>
        /// <param name="prodID"></param>
        /// <param name="quantity"></param>
        /// <param name="orderDate"></param>
        /// <param name="shipDate"></param>
        /// <param name="shipMode"></param>
        /// <returns></returns>
        [HttpPost]
        [EnableCors("MyPolicy")]
        [Route("/create-order")]
        public int CreateNewOrder(string custID, string prodID, int quantity, DateTime orderDate, DateTime shipDate, string shipMode)
        {
            return dbHandler.CreateNewOrder(custID, prodID, quantity, orderDate, shipDate, shipMode);
        }
        
        /// <summary>
        /// Delete an order
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        [HttpDelete]
        [EnableCors("MyPolicy")]
        [Route("/delete-order")]
        public int DeleteOrder(int orderID)
        {
            return dbHandler.DeleteOrder(orderID);
        }

    }
}