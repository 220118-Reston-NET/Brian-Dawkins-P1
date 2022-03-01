global using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBL;
using StoreFrontModel;

/*
    Auto generate by utilizing aspnet-codegenerator tool
    https://docs.microsoft.com/en-us/aspnet/core/fundamentals/tools/dotnet-aspnet-codegenerator?view=aspnetcore-6.0

    -To start
    --Install tool first = dotnet tool install -g dotnet-aspnet-codegenerator
    --Add package to api project = dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
    
    --To create a controller
    dotnet aspnet-codegenerator controller -name StoreApp -api -outDir Controllers -actions

    " dotnet aspnet-codegenerator controller" - creates a controller 

    "-name {NameOfController}" - name the controller to whatever you put

    "-api" - Makes the controller restful style api

    "-outDir Controllers" - Puts the controller inside the controller folder in api project

    "-actions" - Adds in action(methods) in your controller
*/
namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreAppController : ControllerBase
    {
        private IStoreFrontBL _storeBL;
        public StoreAppController(IStoreFrontBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }

        /*
            [HttpGet] data annotation basically tells the compiler that the method will be an action inside of a controller
            specifally this will handle a GET request from the client and send a http response
        */
        // GET: api/StoreApp
        [HttpGet]
        public IActionResult GetAllStores()
        {
            try
            {
                Log.Information("Successfully ran get all stores function");
                return Ok(_storeBL.GetAllStores());
            }
            catch (SqlException)
            {
                Log.Warning("Get all stores encountered error");
                //The API is responsible for sending the right resource and the right status code
                //In this case if it was unable to connect to the database, it will give a 404 status code
                return NotFound();
            }
        }

        /*
            Parameterized action will help you get information from the client and to do some process based on that action
            Yo have to use "{nameOfParameter}" to specify what you need
            Don't forget to put it as a parameter on the action with the appropriate datatype
        */

        //GET: api/StoreApp/5
        [HttpGet("ProductsByID")]
         public IActionResult GetProductsByStoreId(int c_storeId)
        {
            try
            {
                Log.Information("Successfully ran products by store Id");
                return Ok(_storeBL.GetProductsByStoreId(c_storeId));
            }
            catch (SqlException)
            {
                Log.Warning("Issure running products by Id");
                //The API is responsible for sending the right resource and the right status code
                //In this case if it was unable to connect to the database, it will give a 404 status code
                return NotFound();
            }
        }

                // GET: api/StoreApp
        [HttpGet("ViewInventory")]
        public IActionResult ViewInventory(int c_storeId)
        {
            try
            {
                Log.Information("Successfully ran View Inventory function");
                return Ok(_storeBL.ViewInventory(c_storeId));
            }
            catch (SqlException)
            {
                Log.Information("Issue running View Inventory function");
                //The API is responsible for sending the right resource and the right status code
                //In this case if it was unable to connect to the database, it will give a 404 status code
                return NotFound();
            }
        }

        // POST: api/StoreApp
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/StoreApp/5
        [HttpPut("UpdateInventory")]
        public IActionResult Put([FromQuery] int c_empId, string pass, int c_storeId, int c_productId, int c_quantity)
        {
            if(_storeBL.isAdmin(c_empId,pass))
            {
                try
            {
                Log.Information("Successfully Updated Inventory");
                return Ok(_storeBL.ReplenishInventory(c_storeId, c_productId, c_quantity));
            }
            catch (System.Exception ex)
            {
                Log.Warning("Issue updating inventory");
                return Conflict(ex.Message);
            }
            }
            else
            {
                return StatusCode(401, "Access denied for user");
            }
            
        }

        // DELETE: api/StoreApp/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
