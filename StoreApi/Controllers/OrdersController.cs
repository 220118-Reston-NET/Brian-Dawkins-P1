using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBL;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IStoreFrontBL _storeBL;
        public OrdersController(IStoreFrontBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        // GET: api/Orders
        [HttpGet("CustomerIdOrders")]
        public IActionResult GetOrdersByCustomerId(int c_customerId)
        {
            try
            {
                return Ok(_storeBL.GetOrdersByCustomerId(c_customerId));
            }
            catch (SqlException)
            {
                //The API is responsible for sending the right resource and the right status code
                //In this case if it was unable to connect to the database, it will give a 404 status code
                return NotFound();
            }
        }

        //GET: api/Orders/5
        [HttpGet("StoreIdOrders")]
        public IActionResult  GetOrdersByStoreId(int c_storeId)
        {
            try
            {
                return Ok(_storeBL.GetOrdersByStoreId(c_storeId));
            }
            catch (SqlException)
            {
                //The API is responsible for sending the right resource and the right status code
                //In this case if it was unable to connect to the database, it will give a 404 status code
                return NotFound();
            }
        }

        // POST: api/Orders
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
