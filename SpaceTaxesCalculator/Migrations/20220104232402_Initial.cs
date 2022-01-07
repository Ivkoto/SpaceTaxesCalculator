using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaceTaxesCalculator.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spaceships",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseYear = table.Column<int>(type: "int", nullable: false),
                    MilesTraveled = table.Column<long>(type: "bigint", nullable: false),
                    InitialTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxCalculationYear = table.Column<int>(type: "int", nullable: false),
                    TaxDue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaceships", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spaceships");
        }
    }
}
