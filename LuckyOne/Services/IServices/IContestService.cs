using LuckyOne.DTOs.Contests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuckyOne.Services.IServices
{
    public interface IContestService
    {
        Task<List<ContestListItemDto>> GetOpenContestsAsync(int? userId);
        Task<ContestDetailDto?> GetContestDetailAsync(int contestId, int? userId);
        Task<int> CreateContestAsync(ContestCreateDto dto);
        Task<bool> JoinContestAsync(int contestId, int userId);
        Task<List<ContestListItemDto>> GetAllContestsAsync();
    }
}
