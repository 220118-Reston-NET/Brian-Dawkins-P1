using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using StoreBL;

namespace StoreApi.Controllers

{

[ApiController]
[Route("[controller]")]
public class AuthorizationController : ControllerBase
    {
        private IStoreFrontBL _storeBL;
        public AuthorizationController(IStoreFrontBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }

        [HttpGet("Manager")]
        public IActionResult GetEmployee(int c_empId, string pass)
        {
            try
            {
                return Ok(_storeBL.GetEmployee(c_empId, pass));
            }
            catch (SqlException ex)
            {
                //The API is responsible for sending the right resource and the right status code
                //In this case if it was unable to connect to the database, it will give a 404 status code
                return NotFound(ex.Message);
            }
        }
    }
}
    

