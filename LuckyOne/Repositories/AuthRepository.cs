using LuckyOne.Data;
using LuckyOne.DTOs.RequestDtos;
using LuckyOne.Entity;
using LuckyOne.Repositories.IRepository;
using System.Threading.Tasks;

namespace LuckyOne.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        
        private readonly AppDbContext _context ;
        public AuthRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<object> Reister(RegisterRequestDto request)
        {
            var user = new User()
            {
                Username = request.UserName,
                Email = request.Email,
                PasswordHash = request.PasswordHash,
                Mobile = request.Mobile,
            };

            _context.Users.Add(user);
           await _context.SaveChangesAsync();
            return new
            {
                Message = "Resiter Success"
            };
        }
    }
}
