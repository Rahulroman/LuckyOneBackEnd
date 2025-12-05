using System.Collections.Generic;
using System.Threading.Tasks;
using LuckyOne.DTOs.Contests;

namespace LuckyOne.Repositories.IRepository
{
    public interface IContestRepository
    {
        Task<List<ContestListItemDto>> GetOpenContestsAsync(int? userId);
        Task<ContestDetailDto?> GetContestDetailAsync(int contestId, int? userId);
        Task<int> CreateContestAsync(ContestCreateDto dto);
        Task<bool> JoinContestAsync(int contestId, int userId);
        Task<List<ContestListItemDto>> GetAllContestsAsync();

    }
}
