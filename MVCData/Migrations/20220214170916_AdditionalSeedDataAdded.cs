using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCData.Migrations
{
    public partial class AdditionalSeedDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Stad", "Namn", "Telefonnummer" },
                values: new object[] { 4, "TestCity4", "TestPerson4", "0068995543" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Stad", "Namn", "Telefonnummer" },
                values: new object[] { 5, "TestCity5", "TestPerson5", "00356446794" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 5);
        }
    }
}
