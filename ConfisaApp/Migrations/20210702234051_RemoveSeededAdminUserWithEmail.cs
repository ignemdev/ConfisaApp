using Microsoft.EntityFrameworkCore.Migrations;

namespace ConfisaApp.Migrations
{
    public partial class RemoveSeededAdminUserWithEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", "f512dbb0-a10e-40b7-a57e-1f92e918f70a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "5e6b6c32-1834-4e25-b5e5-5cb361877381", "ignaciomp.dev@gmail.com", true, false, null, "IGNACIOMP.DEV@GMAIL.COM", "IGNACIOMP.DEV@GMAIL.COM", "AQAAAAEAACcQAAAAEPTf5cn6mOyobxF8NMg61P40SXGxBl6X+psNvQxNCDTGrSUIcShVM2Z9KCAiM9MARg==", null, false, "171856ee-e347-4e76-8a2a-89faa8f2f08e", false, "ignaciomp.dev@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });
        }
    }
}
