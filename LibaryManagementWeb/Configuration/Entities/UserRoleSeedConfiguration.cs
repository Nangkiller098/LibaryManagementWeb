using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibaryManagementWeb.Configuration.Entities
{
    internal class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "11ba66f2-11c1-1120-11be-111ec98c6011",
                    UserId = "2aba66f2-76c1-4120-b0be-ea1ec98c6026",
                },
                new IdentityUserRole<string>
                {
                    RoleId = "12ba66f2-12c1-1220-11be-121ec98c6012",
                    UserId = "78e6e5a8-0d19-4710-8a4c-95cc89545e60",
                }
                );
        }
    }
}