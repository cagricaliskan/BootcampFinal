using Microsoft.EntityFrameworkCore.Migrations;

namespace BootcampFinal.Migrations
{
    public partial class its : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_BuildingTypes_BuildingTypeId",
                table: "Buildings");

            migrationBuilder.DropTable(
                name: "BuildingTypes");

            migrationBuilder.DropIndex(
                name: "IX_Buildings_BuildingTypeId",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "BuildingTypeId",
                table: "Buildings");

            migrationBuilder.AddColumn<int>(
                name: "FlatTypeId",
                table: "Flats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FlatTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlatTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flats_FlatTypeId",
                table: "Flats",
                column: "FlatTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_FlatTypes_FlatTypeId",
                table: "Flats",
                column: "FlatTypeId",
                principalTable: "FlatTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flats_FlatTypes_FlatTypeId",
                table: "Flats");

            migrationBuilder.DropTable(
                name: "FlatTypes");

            migrationBuilder.DropIndex(
                name: "IX_Flats_FlatTypeId",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "FlatTypeId",
                table: "Flats");

            migrationBuilder.AddColumn<int>(
                name: "BuildingTypeId",
                table: "Buildings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BuildingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_BuildingTypeId",
                table: "Buildings",
                column: "BuildingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_BuildingTypes_BuildingTypeId",
                table: "Buildings",
                column: "BuildingTypeId",
                principalTable: "BuildingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
