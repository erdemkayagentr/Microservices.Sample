using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kocsistem.RabbitMQ.Payment.Data.Migrations
{
    public partial class InitialPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentRate",
                table: "PaymentDetail");

            migrationBuilder.RenameColumn(
                name: "BasketId",
                table: "PaymentDetail",
                newName: "UserId");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PaymentDetail",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "PaymentDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "PaymentDetail");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PaymentDetail",
                newName: "BasketId");

            migrationBuilder.AddColumn<string>(
                name: "PaymentRate",
                table: "PaymentDetail",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
