namespace LuckyOne.DTOs.RequestDtos
{

    public class RegisterRequestDto
    {
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string Mobile { get; set; } = "";
    }
}
