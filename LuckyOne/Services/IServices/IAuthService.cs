using LuckyOne.DTOs.RequestDtos;
using System.Threading.Tasks;

namespace LuckyOne.Services.IServices
{
    public interface IAuthService
    {
        Task<object> register(RegisterRequestDto request);
    }
}
