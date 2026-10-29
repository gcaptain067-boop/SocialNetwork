using Microsoft.EntityFrameworkCore;
using SocialNetwork.Api.Entities;

namespace SocialNetwork.Api.Data.Configurations
{
    public class ApiSessionConfiguration : IEntityTypeConfiguration<Entities.ApiSession>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.ApiSession> builder)
        {
            builder.Property(a => a.ClientApp).HasMaxLength(10).IsRequired();
            

            builder.HasOne<ApplicationUser>()
                 .WithMany()
                 .HasForeignKey(a => a.UserId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(s => new { s.UserId, s.RevokedAt });

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_ApiSession_Expires", "[ExpiresAt] > [CreatedAt]");
                t.HasCheckConstraint("CK_ApiSession_ClientApp", "[ClientApp] IN ('Web','Admin')");
            });

        }
    }
}
