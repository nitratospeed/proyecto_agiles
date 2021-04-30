using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Persistence.Migrations
{
    public partial class AddedTemas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TemaId",
                table: "Cursos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UrlVideo",
                table: "Cursos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Temas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_TemaId",
                table: "Cursos",
                column: "TemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Temas_UsuarioId",
                table: "Temas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Temas_TemaId",
                table: "Cursos",
                column: "TemaId",
                principalTable: "Temas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Temas_TemaId",
                table: "Cursos");

            migrationBuilder.DropTable(
                name: "Temas");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_TemaId",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "TemaId",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "UrlVideo",
                table: "Cursos");
        }
    }
}
