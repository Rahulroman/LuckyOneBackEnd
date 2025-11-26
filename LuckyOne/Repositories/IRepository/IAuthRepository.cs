using LuckyOne.DTOs.RequestDtos;
using Microsoft.AspNetCore.Identity.Data;
using System.Threading.Tasks;

namespace LuckyOne.Repositories.IRepository
{
    public interface IAuthRepository
    {
        Task<object> Reister(RegisterRequestDto user);
    }
}
