using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroPersona.Migrations
{
    public partial class eliminando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonaDetalle");

            migrationBuilder.DropTable(
                name: "TipoTelefono");

            migrationBuilder.AddColumn<int>(
                name: "OcupacionId",
                table: "Personas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Personas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OcupacionId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Personas");

            migrationBuilder.CreateTable(
                name: "TipoTelefono",
                columns: table => new
                {
                    TiposTelefonoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTelefono", x => x.TiposTelefonoId);
                });

            migrationBuilder.CreateTable(
                name: "PersonaDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Persona = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonaDetalle_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId");
                    table.ForeignKey(
                        name: "FK_PersonaDetalle_TipoTelefono_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TipoTelefono",
                        principalColumn: "TiposTelefonoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoTelefono",
                columns: new[] { "TiposTelefonoId", "Descripcion" },
                values: new object[] { 1, "Casa" });

            migrationBuilder.InsertData(
                table: "TipoTelefono",
                columns: new[] { "TiposTelefonoId", "Descripcion" },
                values: new object[] { 2, "Celular" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonaDetalle_PersonaId",
                table: "PersonaDetalle",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaDetalle_TipoId",
                table: "PersonaDetalle",
                column: "TipoId");
        }
    }
}
