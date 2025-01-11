using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace System_do_zarządzania_ligą_piłkarską.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class twentyFour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Images_TrophyId",
                table: "Images");

            migrationBuilder.CreateIndex(
                name: "IX_Trophies_LeagueSeasonId",
                table: "Trophies",
                column: "LeagueSeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_TrophyId",
                table: "Images",
                column: "TrophyId",
                unique: true,
                filter: "[TrophyId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Trophies_LeagueSeasons_LeagueSeasonId",
                table: "Trophies",
                column: "LeagueSeasonId",
                principalTable: "LeagueSeasons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trophies_LeagueSeasons_LeagueSeasonId",
                table: "Trophies");

            migrationBuilder.DropIndex(
                name: "IX_Trophies_LeagueSeasonId",
                table: "Trophies");

            migrationBuilder.DropIndex(
                name: "IX_Images_TrophyId",
                table: "Images");

            migrationBuilder.CreateIndex(
                name: "IX_Images_TrophyId",
                table: "Images",
                column: "TrophyId");
        }
    }
}
