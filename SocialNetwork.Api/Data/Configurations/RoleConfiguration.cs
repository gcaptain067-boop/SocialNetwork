using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SocialNetwork.Api.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public static readonly Guid UserRoleId =
            Guid.Parse("11111111-1111-1111-1111-111111111111");

        public static readonly Guid SuperAdminRoleId =
            Guid.Parse("22222222-2222-2222-2222-222222222222");

        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            builder.HasData(
                new IdentityRole<Guid>
                {
                    Id = UserRoleId,
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "a1b2c3d4-0001-4000-8000-000000000001"

                },
                new IdentityRole<Guid>
                {
                    Id = SuperAdminRoleId,
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN",
                    ConcurrencyStamp = "a1b2c3d4-0002-4000-8000-000000000002"
                });
        }
    }
}