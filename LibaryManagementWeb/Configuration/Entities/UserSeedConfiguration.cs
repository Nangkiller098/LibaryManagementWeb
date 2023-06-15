using LibaryManagementWeb.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibaryManagementWeb.Configuration.Entities
{
    internal class UserSeedConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            var hasher = new PasswordHasher<Employee>();
            builder.HasData(
                new Employee
                {
                    Id = "2aba66f2-76c1-4120-b0be-ea1ec98c6026",
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    FirstName = "system",
                    LastName = "admin",
                    DateJoined = DateTime.Now,
                    DateOfBirth = DateTime.Now,
                    PasswordHash = hasher.HashPassword(null, "$Omnang123"),
                    EmailConfirmed = true
                },
                new Employee
                {
                    Id = "78e6e5a8-0d19-4710-8a4c-95cc89545e60",
                    UserName = "user@gmail.com",
                    NormalizedUserName = "USER@GMAIL.COM",
                    Email = "user@gmail.com",
                    NormalizedEmail = "USER@GMAIL.COM",
                    FirstName = "system",
                    LastName = "user",
                    DateJoined = DateTime.Now,
                    DateOfBirth = DateTime.Now,
                    PasswordHash = hasher.HashPassword(null, "P@ssword123"),
                    EmailConfirmed = true
                }

                ); ;
        }
    }
}