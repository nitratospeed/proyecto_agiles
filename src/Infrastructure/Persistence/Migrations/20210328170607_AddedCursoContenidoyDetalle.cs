using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Persistence.Migrations
{
    public partial class AddedCursoContenidoyDetalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CursoContenidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(maxLength: 250, nullable: false),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoContenidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CursoContenidos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CursoContenidoDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(maxLength: 250, nullable: false),
                    UrlVideo = table.Column<string>(nullable: true),
                    CursoContenidoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoContenidoDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CursoContenidoDetalles_CursoContenidos_CursoContenidoId",
                        column: x => x.CursoContenidoId,
                        principalTable: "CursoContenidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoContenidoDetalles_CursoContenidoId",
                table: "CursoContenidoDetalles",
                column: "CursoContenidoId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoContenidos_CursoId",
                table: "CursoContenidos",
                column: "CursoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoContenidoDetalles");

            migrationBuilder.DropTable(
                name: "CursoContenidos");
        }
    }
}
