using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class AddedTemas3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Temas_Usuarios_UsuarioId",
                table: "Temas");

            migrationBuilder.DropIndex(
                name: "IX_Temas_UsuarioId",
                table: "Temas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Temas");

            migrationBuilder.CreateTable(
                name: "UsuarioTemas",
                columns: table => new
                {
                    TemaId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioTemas", x => new { x.TemaId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_UsuarioTemas_Temas_TemaId",
                        column: x => x.TemaId,
                        principalTable: "Temas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioTemas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioTemas_UsuarioId",
                table: "UsuarioTemas",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioTemas");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Temas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Temas_UsuarioId",
                table: "Temas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Temas_Usuarios_UsuarioId",
                table: "Temas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
