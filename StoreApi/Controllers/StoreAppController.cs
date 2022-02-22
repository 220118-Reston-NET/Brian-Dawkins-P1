using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBL;

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

        // GET: api/StoreApp
        [HttpGet]
        public IActionResult GetAllStores()
        {
            try
            {
                return Ok(_storeBL.GetAllStores());
            }
            catch (SqlException)
            {
                //The API is responsible for sending the right resource and the right status code
                //In this case if it was unable to connect to the database, it will give a 404 status code
                return NotFound();
            }
        }

        //GET: api/StoreApp/5
        [HttpGet("ProductsByID")]
         public IActionResult GetProductsByStoreId(int c_storeId)
        {
            try
            {
                return Ok(_storeBL.GetProductsByStoreId(c_storeId));
            }
            catch (SqlException)
            {
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
                return Ok(_storeBL.ViewInventory(c_storeId));
            }
            catch (SqlException)
            {
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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/StoreApp/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
