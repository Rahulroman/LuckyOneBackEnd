using LuckyOne.DTOs.RequestDtos;
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
        public async Task<IActionResult> register(RegisterRequestDto user) 
        {
            try
            {
                var response = await _authService.register(user);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
