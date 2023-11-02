using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RadioCab.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PAdvertismentApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PAdvertisment",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PAdvertisment",
                table: "AspNetUsers");
        }
    }
}
