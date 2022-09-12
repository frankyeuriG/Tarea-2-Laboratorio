using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroPersona.Migrations
{
    public partial class Segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Ocupaciones_OcupacionId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_OcupacionId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "OcupacionId",
                table: "Personas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OcupacionId",
                table: "Personas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_OcupacionId",
                table: "Personas",
                column: "OcupacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Ocupaciones_OcupacionId",
                table: "Personas",
                column: "OcupacionId",
                principalTable: "Ocupaciones",
                principalColumn: "OcupacionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
