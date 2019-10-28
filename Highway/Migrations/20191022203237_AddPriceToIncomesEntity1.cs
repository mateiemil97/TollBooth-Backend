using Microsoft.EntityFrameworkCore.Migrations;

namespace Highway.Migrations
{
    public partial class AddPriceToIncomesEntity1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Incomes",
                newName: "Amount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Incomes",
                newName: "Price");
        }
    }
}
