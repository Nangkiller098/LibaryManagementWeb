using LibaryManagementWeb.Contract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibaryManagementWeb.Configuration.Entities
{
    internal class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "11ba66f2-11c1-1120-11be-111ec98c6011",
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpper(),
                },
                 new IdentityRole
                 {
                     Id = "12ba66f2-12c1-1220-11be-121ec98c6012",
                     Name = Roles.User,
                     NormalizedName = Roles.User.ToUpper(),
                 }
                ); ;
        }
    }
}