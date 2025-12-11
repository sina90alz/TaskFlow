namespace TaskFlow.API.Models
{
    public class RegisterModel
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
