using LuckyOne.DTOs.RequestDtos;
using LuckyOne.Entity;
using LuckyOne.Helper;
using LuckyOne.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LuckyOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
       public AuthController(IAuthService authService)
        {
            _authService = authService;
        }



       
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> register(RegisterRequestDto request) 
        {
            try
            {
                var response = await _authService.register(request);
                return Ok( new { Status = true, response = response });
            }
            catch (Exception ex)
            { 
                return BadRequest(new { Status = false, Response = ex.Message });
            }
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login(LoginRequestDto request) 
        {
            try
            {
                var result = await _authService.Login(request);

                if (result != null)
                {
                    return Ok(new { Status = true, Response = "Login Success", Token = result });
                }
                else
                {
                    return Ok(new { Status = false, Response = "Invalid Login", Token = "" });
                }

                    
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = false, Response = ex.Message });
            }
        }





    }
}
