using Microsoft.EntityFrameworkCore.Migrations;

namespace PaladinsLoadoutSelector.Data.Migrations
{
    public partial class addchampioncard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChampionId",
                table: "Cards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ChampionId",
                table: "Cards",
                column: "ChampionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Champions_ChampionId",
                table: "Cards",
                column: "ChampionId",
                principalTable: "Champions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Champions_ChampionId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_ChampionId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ChampionId",
                table: "Cards");
        }
    }
}
