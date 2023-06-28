using Microsoft.EntityFrameworkCore.Migrations;

namespace LibaryManagementWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultRoleUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11ba66f2-11c1-1120-11be-111ec98c6011", null, "Administrator", "ADMINISTRATOR" },
                    { "12ba66f2-12c1-1220-11be-121ec98c6012", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2aba66f2-76c1-4120-b0be-ea1ec98c6026", 0, "9645be4d-6a48-47d0-94a7-1f60e19f2696", new DateTime(2023, 6, 15, 10, 37, 15, 694, DateTimeKind.Local).AddTicks(7308), new DateTime(2023, 6, 15, 10, 37, 15, 694, DateTimeKind.Local).AddTicks(7321), "admin@gmail.com", true, "system", "admin", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEAIk4bqbsBUGKXqNEETUsYKSxWP26m/u+tKWOmdXegxTIePPfijDeFgqadA4lgYNOw==", null, false, "84c3d2ba-e5a4-4e91-8f8f-a07257bbca22", null, false, "admin@gmail.com" },
                    { "78e6e5a8-0d19-4710-8a4c-95cc89545e60", 0, "59673448-9c85-411f-a960-3173a89a85eb", new DateTime(2023, 6, 15, 10, 37, 15, 745, DateTimeKind.Local).AddTicks(2886), new DateTime(2023, 6, 15, 10, 37, 15, 745, DateTimeKind.Local).AddTicks(2907), "user@gmail.com", true, "system", "user", false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEKS96xIvhUgI3PQsaMoDZzpUKNVrH4/Ztj/UbfO19d8z28YdX6IO3CnzkfLAmN/rQQ==", null, false, "ec44abdf-a07c-4f86-96a8-c9e18500e0fa", null, false, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "11ba66f2-11c1-1120-11be-111ec98c6011", "2aba66f2-76c1-4120-b0be-ea1ec98c6026" },
                    { "12ba66f2-12c1-1220-11be-121ec98c6012", "78e6e5a8-0d19-4710-8a4c-95cc89545e60" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "11ba66f2-11c1-1120-11be-111ec98c6011", "2aba66f2-76c1-4120-b0be-ea1ec98c6026" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "12ba66f2-12c1-1220-11be-121ec98c6012", "78e6e5a8-0d19-4710-8a4c-95cc89545e60" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11ba66f2-11c1-1120-11be-111ec98c6011");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12ba66f2-12c1-1220-11be-121ec98c6012");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2aba66f2-76c1-4120-b0be-ea1ec98c6026");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78e6e5a8-0d19-4710-8a4c-95cc89545e60");
        }
    }
}
