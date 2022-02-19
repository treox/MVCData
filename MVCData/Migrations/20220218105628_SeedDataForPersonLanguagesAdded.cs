using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCData.Migrations
{
    public partial class SeedDataForPersonLanguagesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Språk" },
                values: new object[] { 1, "Svenska" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Språk" },
                values: new object[] { 2, "Amerikanska" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Språk" },
                values: new object[] { 3, "Australienska" });

            migrationBuilder.InsertData(
                table: "LanguageOwner",
                columns: new[] { "PersonLanguageId", "LanguageRefId", "PersonRefId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 2, 3 },
                    { 4, 3, 4 },
                    { 5, 3, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LanguageOwner",
                keyColumn: "PersonLanguageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LanguageOwner",
                keyColumn: "PersonLanguageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LanguageOwner",
                keyColumn: "PersonLanguageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LanguageOwner",
                keyColumn: "PersonLanguageId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LanguageOwner",
                keyColumn: "PersonLanguageId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 3);
        }
    }
}
