using Microsoft.EntityFrameworkCore.Migrations;

namespace BootcampFinal.Migrations
{
    public partial class inittt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flats_FlatTypes_FlatTypeId",
                table: "Flats");

            migrationBuilder.DropIndex(
                name: "IX_Flats_FlatTypeId",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "FlatTypeId",
                table: "Flats");

            migrationBuilder.AddColumn<int>(
                name: "FlatTypeId",
                table: "BuildingFlats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BuildingFlats_FlatTypeId",
                table: "BuildingFlats",
                column: "FlatTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingFlats_FlatTypes_FlatTypeId",
                table: "BuildingFlats",
                column: "FlatTypeId",
                principalTable: "FlatTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingFlats_FlatTypes_FlatTypeId",
                table: "BuildingFlats");

            migrationBuilder.DropIndex(
                name: "IX_BuildingFlats_FlatTypeId",
                table: "BuildingFlats");

            migrationBuilder.DropColumn(
                name: "FlatTypeId",
                table: "BuildingFlats");

            migrationBuilder.AddColumn<int>(
                name: "FlatTypeId",
                table: "Flats",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
