using Microsoft.EntityFrameworkCore.Migrations;

namespace ConfisaApp.Migrations
{
    public partial class RemoveEmailRequieredOficialId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dealers_Oficiales_OficialId",
                table: "Dealers");

            migrationBuilder.AlterColumn<int>(
                name: "OficialId",
                table: "Dealers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Dealers_Oficiales_OficialId",
                table: "Dealers",
                column: "OficialId",
                principalTable: "Oficiales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dealers_Oficiales_OficialId",
                table: "Dealers");

            migrationBuilder.AlterColumn<int>(
                name: "OficialId",
                table: "Dealers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dealers_Oficiales_OficialId",
                table: "Dealers",
                column: "OficialId",
                principalTable: "Oficiales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
