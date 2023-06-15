using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibaryManagementWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingPeriodToAllocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2aba66f2-76c1-4120-b0be-ea1ec98c6026",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63fecb22-aca5-4a5c-968d-fd0690024ee2", new DateTime(2023, 6, 15, 21, 14, 2, 375, DateTimeKind.Local).AddTicks(218), new DateTime(2023, 6, 15, 21, 14, 2, 375, DateTimeKind.Local).AddTicks(227), "AQAAAAIAAYagAAAAEKJ6FmnIdSHbQsLX7o1052PXUgTKwsS+vgAv+pxIHlRmWvV+hCbcZ2Q3ImI0LwBWWw==", "fec47c8c-8236-4f91-979f-106f6b1bead3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78e6e5a8-0d19-4710-8a4c-95cc89545e60",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0546a3bc-2b75-4df1-b6e2-e1e491f2bc87", new DateTime(2023, 6, 15, 21, 14, 2, 445, DateTimeKind.Local).AddTicks(5885), new DateTime(2023, 6, 15, 21, 14, 2, 445, DateTimeKind.Local).AddTicks(5896), "AQAAAAIAAYagAAAAEBBLIJuTIy2CX/BynX0rvPBHEiFF8VUARRe7N4N9IWnXmLWQqQ/kyydWjZ7ZiYMNOg==", "3599e0cf-8fe5-4b5d-9fb5-bb0854687adc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2aba66f2-76c1-4120-b0be-ea1ec98c6026",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9645be4d-6a48-47d0-94a7-1f60e19f2696", new DateTime(2023, 6, 15, 10, 37, 15, 694, DateTimeKind.Local).AddTicks(7308), new DateTime(2023, 6, 15, 10, 37, 15, 694, DateTimeKind.Local).AddTicks(7321), "AQAAAAIAAYagAAAAEAIk4bqbsBUGKXqNEETUsYKSxWP26m/u+tKWOmdXegxTIePPfijDeFgqadA4lgYNOw==", "84c3d2ba-e5a4-4e91-8f8f-a07257bbca22" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78e6e5a8-0d19-4710-8a4c-95cc89545e60",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59673448-9c85-411f-a960-3173a89a85eb", new DateTime(2023, 6, 15, 10, 37, 15, 745, DateTimeKind.Local).AddTicks(2886), new DateTime(2023, 6, 15, 10, 37, 15, 745, DateTimeKind.Local).AddTicks(2907), "AQAAAAIAAYagAAAAEKS96xIvhUgI3PQsaMoDZzpUKNVrH4/Ztj/UbfO19d8z28YdX6IO3CnzkfLAmN/rQQ==", "ec44abdf-a07c-4f86-96a8-c9e18500e0fa" });
        }
    }
}
