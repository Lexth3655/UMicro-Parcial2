using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UMicro.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modelado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaModificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Editoriales",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_edit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaModificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoriales", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    anio_publicacion = table.Column<int>(type: "int", nullable: false),
                    autorID = table.Column<int>(type: "int", nullable: false),
                    editorialID = table.Column<int>(type: "int", nullable: false),
                    fechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaModificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.id);
                    table.ForeignKey(
                        name: "FK_Libros_Autores_autorID",
                        column: x => x.autorID,
                        principalTable: "Autores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libros_Editoriales_editorialID",
                        column: x => x.editorialID,
                        principalTable: "Editoriales",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_autorID",
                table: "Libros",
                column: "autorID");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_editorialID",
                table: "Libros",
                column: "editorialID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Editoriales");
        }
    }
}
