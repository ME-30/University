using Microsoft.EntityFrameworkCore.Migrations;

namespace University.DAL.Migrations
{
    public partial class m7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Material",
                table: "Courses",
                newName: "MaterialUrl");

            migrationBuilder.AddColumn<string>(
                name: "MaterialName",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialName",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "MaterialUrl",
                table: "Courses",
                newName: "Material");
        }
    }
}
