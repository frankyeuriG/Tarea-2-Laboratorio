using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroPersona.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ocupaciones",
                columns: table => new
                {
                    OcupacionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Salario = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocupaciones", x => x.OcupacionId);
                });

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
                name: "Personas",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OcupacionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.PersonaId);
                    table.ForeignKey(
                        name: "FK_Personas_Ocupaciones_OcupacionId",
                        column: x => x.OcupacionId,
                        principalTable: "Ocupaciones",
                        principalColumn: "OcupacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonaDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Persona = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", nullable: false),
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Personas_OcupacionId",
                table: "Personas",
                column: "OcupacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonaDetalle");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "TipoTelefono");

            migrationBuilder.DropTable(
                name: "Ocupaciones");
        }
    }
}
