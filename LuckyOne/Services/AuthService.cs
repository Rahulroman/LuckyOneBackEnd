using LuckyOne.DTOs.RequestDtos;
using LuckyOne.Repositories.IRepository;
using LuckyOne.Services.IServices;
using System.Threading.Tasks;

namespace LuckyOne.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<object> register(RegisterRequestDto request) 
        {
                return await _authRepository.Reister(request);
        }



    }
}
