using Microsoft.EntityFrameworkCore.Migrations;

namespace ConfisaApp.Migrations
{
    public partial class AddSeededAdminUserWithEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "f512dbb0-a10e-40b7-a57e-1f92e918f70a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e6b6c32-1834-4e25-b5e5-5cb361877381", "ignaciomp.dev@gmail.com", true, "IGNACIOMP.DEV@GMAIL.COM", "AQAAAAEAACcQAAAAEPTf5cn6mOyobxF8NMg61P40SXGxBl6X+psNvQxNCDTGrSUIcShVM2Z9KCAiM9MARg==", "171856ee-e347-4e76-8a2a-89faa8f2f08e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "cc336ee7-855e-4656-8d65-e77ddec9388c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a976a056-50ee-4a67-a94d-5da06e658c1b", null, false, null, "AQAAAAEAACcQAAAAELBfhNnK1hGKN6PLEC2mMjtBcCtL0JuyeSlq80zKQfb29QAYoyAJ1LAy8LM7NPIsoQ==", "b19bf399-88ef-443e-8230-8ed5facbc5c9" });
        }
    }
}
