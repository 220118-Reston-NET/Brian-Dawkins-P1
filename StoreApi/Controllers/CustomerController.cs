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
    public class CustomerController : ControllerBase
    {
        private IStoreFrontBL _storeBL;
        public CustomerController(IStoreFrontBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        // GET: api/Customer
        [HttpGet("GetAll")]
        public IActionResult GetAllCustomers()
        {
            try
            {
                return Ok(_storeBL.GetAllCustomers());
            }
            catch (SqlException)
            {
                //The API is responsible for sending the right resource and the right status code
                //In this case if it was unable to connect to the database, it will give a 404 status code
                return NotFound();
            }
        }
        // GET: api/Customer/5
        [HttpGet("GetById")]
        public IActionResult GetCustomerById(int customerId)
        {
            try
            {
               return Ok(_storeBL.GetCustomerByID(customerId));  
            }
            catch (SqlException)
            {
                //The API is responsible for sending the right resource and the right status code
                //In this case if it was unable to connect to the database, it will give a 404 status code
                return NotFound();
            }
           
        }

        [HttpGet("SearchCustomer")]
        public IActionResult SearchCustomer(string c_name)
        {
            try
            {
               return Ok(_storeBL.SearchCustomer(c_name));  
            }
            catch (SqlException)
            {
                //The API is responsible for sending the right resource and the right status code
                //In this case if it was unable to connect to the database, it will give a 404 status code
                return NotFound();
            }
           
        }

        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}