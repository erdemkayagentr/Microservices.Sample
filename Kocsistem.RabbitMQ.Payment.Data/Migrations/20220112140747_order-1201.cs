using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kocsistem.RabbitMQ.Payment.Data.Migrations
{
    public partial class order1201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "PaymentDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "PaymentDetail");
        }
    }
}
