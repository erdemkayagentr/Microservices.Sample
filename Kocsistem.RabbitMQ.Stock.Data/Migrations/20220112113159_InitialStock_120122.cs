using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kocsistem.RabbitMQ.Stock.Data.Migrations
{
    public partial class InitialStock_120122 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Piece",
                table: "StockDetail",
                newName: "StockQuantity");

            migrationBuilder.AddColumn<decimal>(
                name: "PieceAmount",
                table: "StockDetail",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PieceAmount",
                table: "StockDetail");

            migrationBuilder.RenameColumn(
                name: "StockQuantity",
                table: "StockDetail",
                newName: "Piece");
        }
    }
}
