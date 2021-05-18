using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kocsistem.RabbitMQ.Payment.Data.Migrations
{
    public partial class PaymetDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BasketId = table.Column<Guid>(nullable: false),
                    StockId = table.Column<Guid>(nullable: false),
                    PaymentRate = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    PayDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetail", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentDetail");
        }
    }
}
