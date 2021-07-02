using Microsoft.EntityFrameworkCore.Migrations;

namespace ConfisaApp.Migrations
{
    public partial class AddSeededAdminUserWithEmailAndConfirmation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", "5b921400-af17-46aa-a974-a54770d7a010", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "0ed49030-a487-42bc-8532-28371c1e507e", "ignaciomp.dev@gmail.com", true, false, null, "IGNACIOMP.DEV@GMAIL.COM", "IGNACIOMP.DEV@GMAIL.COM", "AQAAAAEAACcQAAAAEEKPpkzrHewHzJ8BQpZ+N7ZJTN9X/THuYztRUoVCg42aJrRPe6MDNfPMWUds03ysGQ==", null, false, "3c9b87bc-9c44-4220-bcaa-1a3cfd77ff10", false, "ignaciomp.dev@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
