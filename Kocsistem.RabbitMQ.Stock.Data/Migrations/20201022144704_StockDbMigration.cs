using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kocsistem.RabbitMQ.Stock.Data.Migrations
{
    public partial class StockDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    Piece = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockDetail", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockDetail");
        }
    }
}
