using Microsoft.EntityFrameworkCore.Migrations;

namespace Highway.Migrations
{
    public partial class AddLocationToIncomes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Incomes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_LocationId",
                table: "Incomes",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_Location_LocationId",
                table: "Incomes",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_Location_LocationId",
                table: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_Incomes_LocationId",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Incomes");
        }
    }
}
