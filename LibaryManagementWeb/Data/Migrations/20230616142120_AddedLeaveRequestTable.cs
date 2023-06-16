using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibaryManagementWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedLeaveRequestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    RequestingEmpolyeeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2aba66f2-76c1-4120-b0be-ea1ec98c6026",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d406e2bc-1a62-4a5c-8864-a7ca34d6b4af", new DateTime(2023, 6, 16, 21, 21, 19, 835, DateTimeKind.Local).AddTicks(8284), new DateTime(2023, 6, 16, 21, 21, 19, 835, DateTimeKind.Local).AddTicks(8296), "AQAAAAIAAYagAAAAEEW2w25Y0LJFJ2aHb8RzOReB+PJLEc2SOcT0orn+CGWcTcsDxPmOy0yEkEp/WB0s8w==", "a2923401-5328-4dd2-8a3f-8a0713289da8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78e6e5a8-0d19-4710-8a4c-95cc89545e60",
                columns: new[] { "ConcurrencyStamp", "DateJoined", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45e1c862-09a2-433c-82f6-01998894715b", new DateTime(2023, 6, 16, 21, 21, 19, 897, DateTimeKind.Local).AddTicks(9096), new DateTime(2023, 6, 16, 21, 21, 19, 897, DateTimeKind.Local).AddTicks(9106), "AQAAAAIAAYagAAAAEFLcZhosZLphZFmJID0oEPuRzHvLn5XHT8nOMjWWS+Sq5HWcjmuiyPC/Pf6MCOHvOA==", "11dea378-d3a7-4a9d-b407-7e7fc4b27b8c" });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

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
    }
}
