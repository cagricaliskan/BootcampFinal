using Microsoft.EntityFrameworkCore.Migrations;

namespace BootcampFinal.Migrations
{
    public partial class initt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bill",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "Subscription",
                table: "Buildings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Bill",
                table: "Buildings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Subscription",
                table: "Buildings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
