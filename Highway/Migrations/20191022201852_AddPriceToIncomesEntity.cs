using Microsoft.EntityFrameworkCore.Migrations;

namespace Highway.Migrations
{
    public partial class AddPriceToIncomesEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Incomes",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Incomes");
        }
    }
}
