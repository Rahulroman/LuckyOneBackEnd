using System.Security.Claims;
using System.Threading.Tasks;
using LuckyOne.DTOs.Contests;
using LuckyOne.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LuckyOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContestsController : ControllerBase
    {
        private readonly IContestService _contestService;


        public ContestsController(IContestService contestService) 
        {
            _contestService = contestService; 
        }

        [HttpGet("GetAllContests")]
        public async  Task<IActionResult> GetAllContestsAsync()
        {
            int? userId = null;
            var idClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);



            var contests = _contestService.GetAllContestsAsync();
            return Ok(contests);
        }

        [HttpGet("GetOpenContests")]
        public async Task<IActionResult> GetOpenContestsAsync()
        {
            int? userId = null;
            var idClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (idClaim != null)
            {
                userId = int.Parse(idClaim);
            }
            var contests = await _contestService.GetOpenContestsAsync(userId);
            return Ok(contests);
        }

        [HttpGet("GetContestDetail/{contestId}")]
        public async Task<IActionResult> GetContestDetailAsync(int contestId)
        {
            int? userId = null;
            var idClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (idClaim != null)
            {
                userId = int.Parse(idClaim);
            }
            var contestDetail = await _contestService.GetContestDetailAsync(contestId, userId);
            if (contestDetail == null)
            {
                return NotFound();
            }
            return Ok(contestDetail);
        }

        [HttpPost("CreateContest")]
        public async Task<IActionResult> CreateContestAsync([FromBody] ContestCreateDto dto)
        {
            var contestId = await _contestService.CreateContestAsync(dto);
            return CreatedAtAction(nameof(GetContestDetailAsync), new { contestId = contestId }, null);
        }

        [HttpPost("JoinContest/{contestId}")]
        public async Task<IActionResult> JoinContestAsync(int contestId)
        {
            var idClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (idClaim == null)
            {
                return Unauthorized();
            }
            int userId = int.Parse(idClaim);
            var result = await _contestService.JoinContestAsync(contestId, userId);
            if (!result)
            {
                return BadRequest("Unable to join the contest.");
            }
            return Ok();
        }




    }
}
