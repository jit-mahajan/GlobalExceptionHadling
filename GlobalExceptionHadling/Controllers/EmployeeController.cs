using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace GlobalExceptionHadling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            throw new Exception("Test Exception");
         return Ok(new [] { 1, 2, 3});
        }

        public async Task<IActionResult> GetById()
        {
            throw new NotImplementedException("This Method is not implemented");
        }
    }
}
