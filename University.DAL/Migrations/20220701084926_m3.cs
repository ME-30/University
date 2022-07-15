using Microsoft.EntityFrameworkCore.Migrations;

namespace University.DAL.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostionId",
                table: "Stuff",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Postion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postion", x => x.id);
                    table.ForeignKey(
                        name: "FK_Postion_Track_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Track",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stuff_PostionId",
                table: "Stuff",
                column: "PostionId");

            migrationBuilder.CreateIndex(
                name: "IX_Postion_TrackId",
                table: "Postion",
                column: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stuff_Postion_PostionId",
                table: "Stuff",
                column: "PostionId",
                principalTable: "Postion",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stuff_Postion_PostionId",
                table: "Stuff");

            migrationBuilder.DropTable(
                name: "Postion");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropIndex(
                name: "IX_Stuff_PostionId",
                table: "Stuff");

            migrationBuilder.DropColumn(
                name: "PostionId",
                table: "Stuff");
        }
    }
}
