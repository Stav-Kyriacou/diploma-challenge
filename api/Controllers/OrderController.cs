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
    public class OrderController : ControllerBase
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
        public int CreateNewOrder(string custID, string prodID, int quantity, string orderDate, string shipDate, string shipMode)
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

        /// <summary>
        /// Update an order
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="orderDate"></param>
        /// <param name="quantity"></param>
        /// <param name="shipDate"></param>
        /// <param name="custID"></param>
        /// <param name="prodID"></param>
        /// <param name="shipMode"></param>
        /// <returns></returns>
        [HttpPut]
        [EnableCors("MyPolicy")]
        [Route("/update-order")]
        public string UpdateOrder(int orderID, string orderDate, int quantity, string shipDate, string custID, string prodID, string shipMode)
        {
            return dbHandler.UpdateOrder(orderID, orderDate, quantity, shipDate, custID, prodID, shipMode);
        }
    }
}