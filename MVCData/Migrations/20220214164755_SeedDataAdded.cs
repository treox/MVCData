using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCData.Migrations
{
    public partial class SeedDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Stad", "Namn", "Telefonnummer" },
                values: new object[] { 1, "TestCity1", "TestPerson1", "001234567" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Stad", "Namn", "Telefonnummer" },
                values: new object[] { 2, "TestCity2", "TestPerson2", "003554321" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Stad", "Namn", "Telefonnummer" },
                values: new object[] { 3, "TestCity3", "TestPerson3", "004466732" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 3);
        }
    }
}
