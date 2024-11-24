using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace nest.core.infraestructura.db.Security
{
    public class ApplicationUserTokenEntityConfig : IEntityTypeConfiguration<IdentityUserToken<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
        {
            builder.Property(e => e.Value).HasMaxLength(-1);
        }
    }
}
