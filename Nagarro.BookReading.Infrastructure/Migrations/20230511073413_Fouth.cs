using Microsoft.EntityFrameworkCore.Migrations;

namespace Nagarro.BookReading.Infrastructure.Migrations
{
    public partial class Fouth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "e71fd47f-abbc-42fd-9fc9-25107c0f6567");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50562f9f-8aeb-4af5-9e79-34e81ba951ac", "AQAAAAEAACcQAAAAEC05FFPdIKDLSL+ZqfvgsXTORrg6j/yUTEQLkZlxwfqWmzfZVZCt1gri/qfdAb3xIw==", "61e644d1-2d71-460b-b505-488ecdaaadb2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "480b15ff-9bcb-4c5d-9ea8-b497e27021d9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b29ab9d4-cb65-4844-af5f-5f33b1e2ab13", "AQAAAAEAACcQAAAAEHwMV4ZN5hWTfmXlWfeV0hWbIkyjzOtrh5BUateurquoWkJKMLb6A8R2RmNGArokRA==", "3e6c1232-195d-4ff4-897e-5cdfd81705ee" });
        }
    }
}
