using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class CursoAtributosv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BrindaCertificado",
                table: "Cursos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Cursos",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "CostoCertificado",
                table: "Cursos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Cursos",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "Cursos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SubCategoria",
                table: "Cursos",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoAsistencia",
                table: "Cursos",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrindaCertificado",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "CostoCertificado",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "SubCategoria",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "TipoAsistencia",
                table: "Cursos");
        }
    }
}
