using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExampleBank.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldsIntoTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Transaction",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Fee",
                table: "Transaction",
                type: "decimal(25,8)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Fee",
                table: "Transaction");
        }
    }
}
