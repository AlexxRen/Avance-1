using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avance_1.Migrations
{
    /// <inheritdoc />
    public partial class Basedatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    IdPersona = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Nombres = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Fecha_nacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Cedula = table.Column<int>(type: "integer", maxLength: 10, nullable: false)
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
                    Descripcion = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IdPersona = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    DesignioIdPersona = table.Column<string>(type: "character varying(5)", nullable: false),
                    idRole = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    rolIdRol = table.Column<string>(type: "character varying(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agente", x => x.IdAgente);
                    table.ForeignKey(
                        name: "FK_Agente_Persona_DesignioIdPersona",
                        column: x => x.DesignioIdPersona,
                        principalTable: "Persona",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agente_Roles_rolIdRol",
                        column: x => x.rolIdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CamECU911",
                columns: table => new
                {
                    IdCam = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Ubicacion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IdZona = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Zona_designadaIdZona = table.Column<string>(type: "character varying(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CamECU911", x => x.IdCam);
                    table.ForeignKey(
                        name: "FK_CamECU911_Zona_Zona_designadaIdZona",
                        column: x => x.Zona_designadaIdZona,
                        principalTable: "Zona",
                        principalColumn: "IdZona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Siniestro",
                columns: table => new
                {
                    IdSiniestro = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Fecha_Siniestro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Nivel_Siniestro = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    IdCam = table.Column<char>(type: "character(1)", nullable: false),
                    CamdesignadaIdCam = table.Column<string>(type: "character varying(5)", nullable: true),
                    IdAgente = table.Column<string>(type: "text", nullable: false),
                    Agente_designadoIdAgente = table.Column<string>(type: "character varying(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siniestro", x => x.IdSiniestro);
                    table.ForeignKey(
                        name: "FK_Siniestro_Agente_Agente_designadoIdAgente",
                        column: x => x.Agente_designadoIdAgente,
                        principalTable: "Agente",
                        principalColumn: "IdAgente");
                    table.ForeignKey(
                        name: "FK_Siniestro_CamECU911_CamdesignadaIdCam",
                        column: x => x.CamdesignadaIdCam,
                        principalTable: "CamECU911",
                        principalColumn: "IdCam");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agente_DesignioIdPersona",
                table: "Agente",
                column: "DesignioIdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Agente_rolIdRol",
                table: "Agente",
                column: "rolIdRol");

            migrationBuilder.CreateIndex(
                name: "IX_CamECU911_Zona_designadaIdZona",
                table: "CamECU911",
                column: "Zona_designadaIdZona");

            migrationBuilder.CreateIndex(
                name: "IX_Siniestro_Agente_designadoIdAgente",
                table: "Siniestro",
                column: "Agente_designadoIdAgente");

            migrationBuilder.CreateIndex(
                name: "IX_Siniestro_CamdesignadaIdCam",
                table: "Siniestro",
                column: "CamdesignadaIdCam");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Siniestro");

            migrationBuilder.DropTable(
                name: "Agente");

            migrationBuilder.DropTable(
                name: "CamECU911");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Zona");
        }
    }
}
