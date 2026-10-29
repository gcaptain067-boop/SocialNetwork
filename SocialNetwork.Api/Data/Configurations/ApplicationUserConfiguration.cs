using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Api.Entities;
namespace SocialNetwork.Api.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            
            builder.Property(a => a.Email).HasMaxLength(256);
            builder.Property(a => a.NormalizedEmail).HasMaxLength(256);
            builder.Property(a => a.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(a => a.LastName).HasMaxLength(50).IsRequired();
            builder.Property(a => a.IsActive).HasDefaultValue(true);
            builder.Property(a => a.MustChangePassword).HasDefaultValue(false);
           

            builder.HasIndex(u => u.NormalizedEmail)
                 .HasDatabaseName("EmailIndex")
                 .IsUnique()
                 .HasFilter("[NormalizedEmail] IS NOT NULL");
        }
    }
}
