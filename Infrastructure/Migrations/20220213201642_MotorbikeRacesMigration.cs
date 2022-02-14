using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class MotorbikeRacesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarRaces_CarRaceid",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "CarRaceid",
                table: "Cars",
                newName: "CarRaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_CarRaceid",
                table: "Cars",
                newName: "IX_Cars_CarRaceId");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "CarRaces",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CarRaces",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "MotorbikeRaceId",
                table: "Motorbikes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MotorbikeRaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    TimeLimit = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorbikeRaces", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motorbikes_MotorbikeRaceId",
                table: "Motorbikes",
                column: "MotorbikeRaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarRaces_CarRaceId",
                table: "Cars",
                column: "CarRaceId",
                principalTable: "CarRaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorbikes_MotorbikeRaces_MotorbikeRaceId",
                table: "Motorbikes",
                column: "MotorbikeRaceId",
                principalTable: "MotorbikeRaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarRaces_CarRaceId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorbikes_MotorbikeRaces_MotorbikeRaceId",
                table: "Motorbikes");

            migrationBuilder.DropTable(
                name: "MotorbikeRaces");

            migrationBuilder.DropIndex(
                name: "IX_Motorbikes_MotorbikeRaceId",
                table: "Motorbikes");

            migrationBuilder.DropColumn(
                name: "MotorbikeRaceId",
                table: "Motorbikes");

            migrationBuilder.RenameColumn(
                name: "CarRaceId",
                table: "Cars",
                newName: "CarRaceid");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_CarRaceId",
                table: "Cars",
                newName: "IX_Cars_CarRaceid");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "CarRaces",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CarRaces",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarRaces_CarRaceid",
                table: "Cars",
                column: "CarRaceid",
                principalTable: "CarRaces",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
