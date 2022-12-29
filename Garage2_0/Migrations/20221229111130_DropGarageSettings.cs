using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage20.Migrations
{
    /// <inheritdoc />
    public partial class DropGarageSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GarageSettings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GarageSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    SlotsTotal = table.Column<int>(type: "int", nullable: false),
                    SlotsUsed = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarageSettings", x => x.Id);
                });
        }
    }
}
