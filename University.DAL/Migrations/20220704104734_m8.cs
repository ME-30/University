using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace University.DAL.Migrations
{
    public partial class m8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stuff_Postion_PostionId",
                table: "Stuff");

            migrationBuilder.RenameColumn(
                name: "PostionId",
                table: "Stuff",
                newName: "Postionid");

            migrationBuilder.RenameIndex(
                name: "IX_Stuff_PostionId",
                table: "Stuff",
                newName: "IX_Stuff_Postionid");

            migrationBuilder.AlterColumn<int>(
                name: "Postionid",
                table: "Stuff",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CollegeId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HareDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollegeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_College_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "College",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CollegeId",
                table: "Courses",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_CollegeId",
                table: "Student",
                column: "CollegeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_College_CollegeId",
                table: "Courses",
                column: "CollegeId",
                principalTable: "College",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stuff_Postion_Postionid",
                table: "Stuff",
                column: "Postionid",
                principalTable: "Postion",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_College_CollegeId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Stuff_Postion_Postionid",
                table: "Stuff");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CollegeId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CollegeId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "Postionid",
                table: "Stuff",
                newName: "PostionId");

            migrationBuilder.RenameIndex(
                name: "IX_Stuff_Postionid",
                table: "Stuff",
                newName: "IX_Stuff_PostionId");

            migrationBuilder.AlterColumn<int>(
                name: "PostionId",
                table: "Stuff",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stuff_Postion_PostionId",
                table: "Stuff",
                column: "PostionId",
                principalTable: "Postion",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
