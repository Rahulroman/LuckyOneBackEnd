using LuckyOne.DTOs.RequestDtos;
using LuckyOne.Entity;
using LuckyOne.Helper;
using LuckyOne.Repositories;
using LuckyOne.Repositories.IRepository;
using LuckyOne.Services.IServices;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace LuckyOne.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly JwtHelper _jwtHelper;
            
        public AuthService(IAuthRepository authRepository, JwtHelper jwtHelper)
        {
            _authRepository = authRepository;
            _jwtHelper = jwtHelper;
        }

        public async Task<object> register(RegisterRequestDto request) 
        {
                return await _authRepository.Reister(request);
        }

        public async Task<object> Login(LoginRequestDto request)
        {
            var result = await _authRepository.Login(request);

            if (result == null)
            {
                return null;
            }

            //string username = result.Username;

            var token = _jwtHelper.GenerateToken(result, false);

            return new { Token = token, Username = result };
        }


    }
}
