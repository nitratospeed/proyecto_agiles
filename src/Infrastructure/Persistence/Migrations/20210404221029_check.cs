using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class check : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CursoUsuario_Cursos_CursoId",
                table: "CursoUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_CursoUsuario_Usuario_UsuarioId",
                table: "CursoUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CursoUsuario",
                table: "CursoUsuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "CursoUsuario",
                newName: "CursoUsuarios");

            migrationBuilder.RenameIndex(
                name: "IX_CursoUsuario_UsuarioId",
                table: "CursoUsuarios",
                newName: "IX_CursoUsuarios_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CursoUsuarios",
                table: "CursoUsuarios",
                columns: new[] { "CursoId", "UsuarioId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CursoUsuarios_Cursos_CursoId",
                table: "CursoUsuarios",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CursoUsuarios_Usuarios_UsuarioId",
                table: "CursoUsuarios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CursoUsuarios_Cursos_CursoId",
                table: "CursoUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_CursoUsuarios_Usuarios_UsuarioId",
                table: "CursoUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CursoUsuarios",
                table: "CursoUsuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "CursoUsuarios",
                newName: "CursoUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_CursoUsuarios_UsuarioId",
                table: "CursoUsuario",
                newName: "IX_CursoUsuario_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CursoUsuario",
                table: "CursoUsuario",
                columns: new[] { "CursoId", "UsuarioId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CursoUsuario_Cursos_CursoId",
                table: "CursoUsuario",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CursoUsuario_Usuario_UsuarioId",
                table: "CursoUsuario",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
