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

        public async Task<List<ContestListItemDto>> GetAllContestsAsync()
        {
            return await _contestRepository.GetAllContestsAsync();
        }

        public async Task<ContestDetailDto> GetContestDetailAsync(int contestId, int? userId)
        {
            return await _contestRepository.GetContestDetailAsync(contestId, userId);
        }

        public async Task<List<ContestListItemDto>> GetOpenContestsAsync(int? userId)
        {
            return await _contestRepository.GetOpenContestsAsync(userId);
        }

        public async Task<bool> JoinContestAsync(int contestId, int userId)
        {
            return await _contestRepository.JoinContestAsync(contestId, userId);
        }
    }
}
