using LuckyOne.DTOs.RequestDtos;

namespace LuckyOne.Services.IServices
{
    public interface IAuthService
    {
        Task<RegisterRequestDto> RegisterAsync(RegisterRequestDto dto);
    }
}
