using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monkeylab.Templates.Infrastructure.Persistences.Migrations
{
    public partial class CreateInitialScheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { new Guid("45cb6716-7c13-4903-be4e-5da0513d834e"), new DateTime(2012, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Customer One" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
