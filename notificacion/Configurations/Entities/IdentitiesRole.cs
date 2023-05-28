using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace notificacion.Configurations.Entities
{
    public class IdentitiesRole : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                     Name = "employed",
                     NormalizedName  ="EMPLOYED"
                },
                 new IdentityRole
                 {
                     Name = "admin",
                     NormalizedName = "ADMIN"
                 },
                 new IdentityRole
                 {
                     Name = "support",
                     NormalizedName = "SUPPORT"
                 }
            );
        }
    }
}
