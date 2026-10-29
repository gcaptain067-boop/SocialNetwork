using Microsoft.AspNetCore.Identity;

namespace SocialNetwork.Api.Entities
{
    public sealed class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public bool MustChangePassword { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
