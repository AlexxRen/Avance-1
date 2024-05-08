using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avance_1.Migrations
{
    /// <inheritdoc />
    public partial class Basedato1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CamECU911",
                columns: table => new
                {
                    IdCam = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Ubicacion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IdZona = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CamECU911", x => x.IdCam);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    IdPersona = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Nombres = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Fecha_nacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Cedula = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.IdPersona);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRol = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Nombre_rol = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Nivel_privilegio = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Zona",
                columns: table => new
                {
                    IdZona = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Descripcion_zona = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zona", x => x.IdZona);
                });

            migrationBuilder.CreateTable(
                name: "Agente",
                columns: table => new
                {
                    IdAgente = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Cargo = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    PersonaId = table.Column<string>(type: "character varying(5)", nullable: false),
                    RolId = table.Column<string>(type: "character varying(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agente", x => x.IdAgente);
                    table.ForeignKey(
                        name: "FK_Agente_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agente_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Siniestro",
                columns: table => new
                {
                    IdSiniestro = table.Column<string>(type: "text", nullable: false),
                    IdZona = table.Column<string>(type: "text", nullable: false),
                    FechaSiniestro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NivelUrgencia = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    IdAgente = table.Column<string>(type: "text", nullable: false),
                    ZonaIdZona = table.Column<string>(type: "character varying(5)", nullable: false),
                    AgenteIdAgente = table.Column<string>(type: "character varying(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siniestro", x => x.IdSiniestro);
                    table.ForeignKey(
                        name: "FK_Siniestro_Agente_AgenteIdAgente",
                        column: x => x.AgenteIdAgente,
                        principalTable: "Agente",
                        principalColumn: "IdAgente");
                    table.ForeignKey(
                        name: "FK_Siniestro_Zona_ZonaIdZona",
                        column: x => x.ZonaIdZona,
                        principalTable: "Zona",
                        principalColumn: "IdZona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agente_PersonaId",
                table: "Agente",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Agente_RolId",
                table: "Agente",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Siniestro_AgenteIdAgente",
                table: "Siniestro",
                column: "AgenteIdAgente");

            migrationBuilder.CreateIndex(
                name: "IX_Siniestro_ZonaIdZona",
                table: "Siniestro",
                column: "ZonaIdZona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CamECU911");

            migrationBuilder.DropTable(
                name: "Siniestro");

            migrationBuilder.DropTable(
                name: "Agente");

            migrationBuilder.DropTable(
                name: "Zona");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
