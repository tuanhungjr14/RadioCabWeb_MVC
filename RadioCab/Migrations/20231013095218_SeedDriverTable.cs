using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RadioCab.Migrations
{
    /// <inheritdoc />
    public partial class SeedDriverTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_feedbackTypes",
                table: "feedbackTypes");

            migrationBuilder.RenameTable(
                name: "feedbackTypes",
                newName: "FeedbackTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeedbackTypes",
                table: "FeedbackTypes",
                column: "FeeId");

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverId", "City", "DriverAddress", "DriverDescripts", "DriverName", "DriverPass", "Email", "Experience", "Mobile", "Telephone" },
                values: new object[,]
                {
                    { 1, "HN", "HN", "a", "A", "1", "a@gmail.com", 100, "123456789", "0284320523" },
                    { 2, "HN", "HN", "a", "B", "1", "b@gmail.com", 100, "123456788", "0284320524" },
                    { 3, "HN", "HN", "a", "C", "1", "c@gmail.com", 100, "123456787", "0284320525" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FeedbackTypes",
                table: "FeedbackTypes");

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "FeedbackTypes",
                newName: "feedbackTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_feedbackTypes",
                table: "feedbackTypes",
                column: "FeeId");
        }
    }
}
