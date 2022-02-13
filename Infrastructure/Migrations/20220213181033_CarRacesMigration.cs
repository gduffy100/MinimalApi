using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class CarRacesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarRaceid",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CarRaces",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    TimeLimit = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRaces", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarRaceid",
                table: "Cars",
                column: "CarRaceid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarRaces_CarRaceid",
                table: "Cars",
                column: "CarRaceid",
                principalTable: "CarRaces",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarRaces_CarRaceid",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "CarRaces");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarRaceid",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarRaceid",
                table: "Cars");
        }
    }
}
