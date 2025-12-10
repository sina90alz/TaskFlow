using Microsoft.AspNetCore.Identity;

namespace TaskFlow.Infrastructure.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FullName { get; set; } = string.Empty;
    }
}
