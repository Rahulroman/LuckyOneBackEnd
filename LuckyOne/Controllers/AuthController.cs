using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace LuckyOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> login()
        {
            var result = "data test";
            return  Ok(result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> register() 
        {
            var result = "register called";

            return Ok( result);
        }
    }
}
