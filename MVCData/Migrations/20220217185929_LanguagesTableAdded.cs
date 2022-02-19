using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCData.Migrations
{
    public partial class LanguagesTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Språk = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "LanguageOwner",
                columns: table => new
                {
                    PersonLanguageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonRefId = table.Column<int>(nullable: false),
                    LanguageRefId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageOwner", x => x.PersonLanguageId);
                    table.ForeignKey(
                        name: "FK_LanguageOwner_Languages_LanguageRefId",
                        column: x => x.LanguageRefId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageOwner_People_PersonRefId",
                        column: x => x.PersonRefId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageOwner_LanguageRefId",
                table: "LanguageOwner",
                column: "LanguageRefId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageOwner_PersonRefId",
                table: "LanguageOwner",
                column: "PersonRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageOwner");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
