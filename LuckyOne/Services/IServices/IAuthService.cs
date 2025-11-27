using LuckyOne.DTOs.RequestDtos;
using LuckyOne.Entity;
using System.Threading.Tasks;

namespace LuckyOne.Services.IServices
{
    public interface IAuthService
    {
        Task<object> register(RegisterRequestDto request);
        Task<object> Login(LoginRequestDto requestDto);
    }
}
