using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CustomerModel;
using Microsoft.AspNetCore.Authorization;
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
                Log.Information("Successfully got all customer");
                return Ok(_storeBL.GetAllCustomers());
            }
            catch (SqlException)
            {
                Log.Warning("Issue getting all customers");
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
                Log.Information("Successfully got customer by id");
               return Ok(_storeBL.GetCustomerByID(customerId));  
            }
            catch (SqlException)
            {
                Log.Warning("Issue getting customer by id");
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
                Log.Information("Successfully Searched for Customer");
               return Ok(_storeBL.SearchCustomer(c_name));  
            }
            catch (SqlException)
            {
                Log.Warning("Issue Searching for customer");
                //The API is responsible for sending the right resource and the right status code
                //In this case if it was unable to connect to the database, it will give a 404 status code
                return NotFound();
            }
           
        }

        /*
            [FromBody] datat annotation specifies that this action will look inside of the HTTP request body (which is in a json format) to grab the information it needs
            Usually helpful for large amount of data (creating an account)

            [HttpPost] This action will handle any post request from the client
        */
        [HttpPost("AddCustomer")]
        public IActionResult Post([FromBody] Customer c_customer)
        {
            try
            {
                
                return Created("Successfully added",_storeBL.AddCustomer(c_customer));
            }
            catch (System.Exception ex)
            {
                
                return Conflict(ex.Message);
            }
        }

        // PUT: api/Customer/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
            
        // }

        // DELETE: api/Customer/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
