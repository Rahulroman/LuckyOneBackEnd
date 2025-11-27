using LuckyOne.DTOs.RequestDtos;
using LuckyOne.Entity;
using Microsoft.AspNetCore.Identity.Data;
using System.Threading.Tasks;

namespace LuckyOne.Repositories.IRepository
{
    public interface IAuthRepository
    {
        Task<object> Reister(RegisterRequestDto user);
        Task<object> Login(LoginRequestDto user);          
    }
}
