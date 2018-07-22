using Microsoft.EntityFrameworkCore.Migrations;

namespace PaladinsLoadoutSelector.Data.Migrations
{
    public partial class addloadoutcard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Loadouts_LoadoutId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_LoadoutId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "LoadoutId",
                table: "Cards");

            migrationBuilder.CreateTable(
                name: "LoadoutCards",
                columns: table => new
                {
                    LoadoutId = table.Column<int>(nullable: false),
                    CardId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadoutCards", x => new { x.CardId, x.LoadoutId });
                    table.ForeignKey(
                        name: "FK_LoadoutCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoadoutCards_Loadouts_LoadoutId",
                        column: x => x.LoadoutId,
                        principalTable: "Loadouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoadoutCards_LoadoutId",
                table: "LoadoutCards",
                column: "LoadoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoadoutCards");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Cards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LoadoutId",
                table: "Cards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_LoadoutId",
                table: "Cards",
                column: "LoadoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Loadouts_LoadoutId",
                table: "Cards",
                column: "LoadoutId",
                principalTable: "Loadouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
