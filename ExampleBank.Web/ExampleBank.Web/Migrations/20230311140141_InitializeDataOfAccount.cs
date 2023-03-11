using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExampleBank.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDataOfAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "FirstName", "LastName", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("5c1ebb1c-ade1-43bd-85bc-977e81cadfc2"), "System", new DateTime(2023, 3, 11, 10, 14, 40, 515, DateTimeKind.Utc), "Jon", "Snow", "System", new DateTime(2023, 3, 11, 10, 14, 40, 515, DateTimeKind.Utc) },
                    { new Guid("8382a5a4-c73f-4314-af3e-699c16fca88e"), "System", new DateTime(2023, 3, 11, 10, 14, 40, 515, DateTimeKind.Utc), "Aegon", "Targaryen", "System", new DateTime(2023, 3, 11, 10, 14, 40, 515, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("5c1ebb1c-ade1-43bd-85bc-977e81cadfc2"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("8382a5a4-c73f-4314-af3e-699c16fca88e"));
        }
    }
}
