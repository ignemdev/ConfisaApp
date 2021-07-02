using Microsoft.EntityFrameworkCore.Migrations;

namespace ConfisaApp.Migrations
{
    public partial class AddDealerMissingFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activado",
                table: "Dealers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RNC",
                table: "Dealers",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activado",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "RNC",
                table: "Dealers");
        }
    }
}
