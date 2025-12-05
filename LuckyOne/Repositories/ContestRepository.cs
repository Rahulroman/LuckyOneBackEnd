using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuckyOne.Data;
using LuckyOne.DTOs.Contests;
using LuckyOne.Entity;
using LuckyOne.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LuckyOne.Repositories
{
    public class ContestRepository : IContestRepository
    {
        private readonly AppDbContext _context;

        public ContestRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<int> CreateContestAsync(ContestCreateDto dto)
        {
            var contest = new Contest
            {
                ContestName = dto.ContestName,
                Description = dto.Description,
                EntryPoints = dto.EntryPoints,
                TotalWinners = dto.TotalWinners,
                MaxUsers = dto.MaxUsers,
                ContestDate = dto.ContestDate,
                ResultDeclareTime = dto.ResultDeclareTime,
                Status = "Open"
            };

            await _context.AddAsync(contest);
            await _context.SaveChangesAsync();

            return contest.ContestId;
        }

        public async Task<List<ContestListItemDto>> GetAllContestsAsync()
        {

           var Contest = await(from c in _context.Contests
                                  select new ContestListItemDto
                                  {
                                      ContestId = c.ContestId,
                                      ContestName = c.ContestName,
                                      EntryPoints = c.EntryPoints,
                                      MaxUsers = c.MaxUsers,
                                      // JoinedUsers = c.JoinedUsers.Count,
                                      ContestDate = c.ContestDate,
                                      Status = c.Status
                                  }).ToListAsync();
            return Contest;
        }

        public async Task<ContestDetailDto> GetContestDetailAsync(int contestId, int? userId)
        {

            var contest = await (from cu in _context.ContestUsers
                                 join c in _context.Contests
                                     on cu.ContestId equals c.ContestId
                                 where cu.ContestId == contestId
                                 select new
                                 {
                                     Contest = c,
                                     UserId = cu.UserId
                                 })
                      .ToListAsync();

            if (!contest.Any()) return null;

            // Build the DTO
            var detail = new ContestDetailDto
            {
                ContestId = contest.First().Contest.ContestId,
                ContestName = contest.First().Contest.ContestName,
                Description = contest.First().Contest.Description,
                EntryPoints = contest.First().Contest.EntryPoints,
                MaxUsers = contest.First().Contest.MaxUsers,
                JoinedUsers = contest.Count,
                ContestDate = contest.First().Contest.ContestDate,
                ResultDeclareTime = contest.First().Contest.ResultDeclareTime,
                Status = contest.First().Contest.Status,
             //   UserIds = contest.Select(x => x.UserId).ToList(),
                JoinedByCurrentUser = userId.HasValue &&
                                      contest.Any(x => x.UserId == userId.Value)
            };

            return detail;



        }

        public async Task<List<ContestListItemDto>> GetOpenContestsAsync(int? userId)
        {

            var dateNow = DateTime.UtcNow;

            var contests = await _context.Contests
                .Where(c => c.Status == "Open" && c.ContestDate >= dateNow)
                .Select(c =>  new ContestListItemDto
                {
                    ContestId = c.ContestId,
                    ContestName = c.ContestName,
                    EntryPoints = c.EntryPoints,
                    MaxUsers = c.MaxUsers,
                   // JoinedUsers = c.JoinedUsers.Count,
                    ContestDate = c.ContestDate,
                    Status = c.Status
                }).ToListAsync();

            return contests;
        }

        public async Task<bool> JoinContestAsync(int contestId, int userId)
        {

            var contestData = await (from cu in _context.ContestUsers
                                 join c in _context.ContestUsers on cu.ContestId equals c.ContestId
                                 where cu.ContestId == contestId
                                 select new { Contest = c, UserId = cu.UserId }
                                 ).ToListAsync();

            if (!contestData.Any()) return false;

            //var contest = contestData.First().Contest;
            //if (contest.Status != "OPEN") return false;

            //// Check if user already joined
            //if (contestData.Any(x => x.UserId == userId)) return true;

            //// Check max users
            //if (contest.MaxUsers > 0 && contestData.Count >= contest.MaxUsers) return false;

            //// Check if user has enough points
            //if (!await _walletService.HasEnoughPointsAsync(userId, contest.EntryPoints))
            //    return false;

            //// Deduct points
            //var ok = await _walletService.DeductPointsAsync(userId, contest.EntryPoints, "Joined contest", contest.ContestId);
            //if (!ok) return false;

            // Add user to contest
            _context.ContestUsers.Add(new ContestUser
            {
                ContestId = contestId,
                UserId = userId,
                JoinedDate = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
            return true;

        }
    }
}
