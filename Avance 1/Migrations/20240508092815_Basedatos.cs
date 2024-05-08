using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                    IdPersona = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombres = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Fecha_nacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Cedula = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.IdPersona);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre_rol = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Tipo_privilegio = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Zona",
                columns: table => new
                {
                    IdZona = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                    IdAgente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cargo = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Personaid = table.Column<int>(type: "integer", nullable: false),
                    Rolid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agente", x => x.IdAgente);
                    table.ForeignKey(
                        name: "FK_Agente_Persona_Personaid",
                        column: x => x.Personaid,
                        principalTable: "Persona",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agente_Rol_Rolid",
                        column: x => x.Rolid,
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CamECU911",
                columns: table => new
                {
                    IdCam = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ubicacion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IdZona = table.Column<int>(type: "integer", nullable: false),
                    ZonaIdZona = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CamECU911", x => x.IdCam);
                    table.ForeignKey(
                        name: "FK_CamECU911_Zona_ZonaIdZona",
                        column: x => x.ZonaIdZona,
                        principalTable: "Zona",
                        principalColumn: "IdZona");
                });

            migrationBuilder.CreateTable(
                name: "Siniestro",
                columns: table => new
                {
                    IdSiniestro = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaSiniestro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NivelUrgencia = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    IdZona = table.Column<int>(type: "integer", nullable: false),
                    ZonaIdZona = table.Column<int>(type: "integer", nullable: true),
                    IdAgente = table.Column<int>(type: "integer", nullable: false),
                    AgenteIdAgente = table.Column<int>(type: "integer", nullable: true)
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
                        principalColumn: "IdZona");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agente_Personaid",
                table: "Agente",
                column: "Personaid");

            migrationBuilder.CreateIndex(
                name: "IX_Agente_Rolid",
                table: "Agente",
                column: "Rolid");

            migrationBuilder.CreateIndex(
                name: "IX_CamECU911_ZonaIdZona",
                table: "CamECU911",
                column: "ZonaIdZona");

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
                name: "Rol");
        }
    }
}
