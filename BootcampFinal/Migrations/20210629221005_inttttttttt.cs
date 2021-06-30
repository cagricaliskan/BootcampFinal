using Microsoft.EntityFrameworkCore.Migrations;

namespace BootcampFinal.Migrations
{
    public partial class inttttttttt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingFlats_Payments_PaymentId",
                table: "BuildingFlats");

            migrationBuilder.DropIndex(
                name: "IX_BuildingFlats_PaymentId",
                table: "BuildingFlats");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "BuildingFlats");

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AppointedPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFlatId = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointedPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointedPayments_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointedPayments_UserFlats_UserFlatId",
                        column: x => x.UserFlatId,
                        principalTable: "UserFlats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentTypeId",
                table: "Payments",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointedPayments_PaymentId",
                table: "AppointedPayments",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointedPayments_UserFlatId",
                table: "AppointedPayments",
                column: "UserFlatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_PaymentTypes_PaymentTypeId",
                table: "Payments",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_PaymentTypes_PaymentTypeId",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "AppointedPayments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_PaymentTypeId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "BuildingFlats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuildingFlats_PaymentId",
                table: "BuildingFlats",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingFlats_Payments_PaymentId",
                table: "BuildingFlats",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
