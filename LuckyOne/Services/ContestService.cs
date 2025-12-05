using System.Collections.Generic;
using System.Threading.Tasks;
using LuckyOne.DTOs.Contests;
using LuckyOne.Repositories.IRepository;
using LuckyOne.Services.IServices;

namespace LuckyOne.Services
{


    public class ContestService : IContestService
    {
        private readonly IContestRepository _contestRepository;

        public ContestService(IContestRepository contestRepository)
        {
            _contestRepository = contestRepository;
        }


        public async Task<int> CreateContestAsync(ContestCreateDto dto)
        {
            return await _contestRepository.CreateContestAsync(dto);
        }

        public Task<List<ContestListItemDto>> GetAllContestsAsync()
        {
            return _contestRepository.GetAllContestsAsync();
        }

        public Task<ContestDetailDto> GetContestDetailAsync(int contestId, int? userId)
        {
            return _contestRepository.GetContestDetailAsync(contestId, userId);
        }

        public Task<List<ContestListItemDto>> GetOpenContestsAsync(int? userId)
        {
            return _contestRepository.GetOpenContestsAsync(userId);
        }

        public Task<bool> JoinContestAsync(int contestId, int userId)
        {
            return _contestRepository.JoinContestAsync(contestId, userId);
        }
    }
}
