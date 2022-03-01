using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBL;
using StoreFrontModel;

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
                Log.Information("Successfully retrieved customer order by id");
                return Ok(_storeBL.GetOrdersByCustomerId(c_customerId));
            }
            catch (SqlException)
            {
                Log.Warning("Issue retrieving order by customer id");
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
                Log.Information("Successfully got orders by store id");
                return Ok(_storeBL.GetOrdersByStoreId(c_storeId));
            }
            catch (SqlException)
            {
                Log.Warning("Issue getting orders by store id");
                //The API is responsible for sending the right resource and the right status code
                //In this case if it was unable to connect to the database, it will give a 404 status code
                return NotFound();
            }
        }

        // POST: api/Orders
        [HttpPost("PlaceOrder")]
        public IActionResult Post(int c_customerId, [FromBody] List<LineItems> c_cart, int c_storeId, int c_total)
        {
            try
            {
                Log.Information("Order successfully created");
                _storeBL.PlaceOrder(c_customerId, c_storeId, c_total, c_cart);
               return Created("Successfully Created", ""); 
            }
            catch (System.Exception ex)
            {
                Log.Warning("Issure creating order");
                return Conflict(ex.Message);
            }
            
        }

        // PUT: api/Orders/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // DELETE: api/Orders/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
