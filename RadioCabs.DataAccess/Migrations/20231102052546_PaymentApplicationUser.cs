using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RadioCab.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PaymentApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Payment",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Payment",
                table: "AspNetUsers");
        }
    }
}
