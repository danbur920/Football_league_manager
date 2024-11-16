using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace System_do_zarządzania_ligą_piłkarską.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class sixteen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballerStats_LeagueSeasons_LeagueId",
                table: "FootballerStats");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_LeagueSeasons_LeagueId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_RefereeStats_LeagueSeasons_LeagueId",
                table: "RefereeStats");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamStats_LeagueSeasons_LeagueId",
                table: "TeamStats");

            migrationBuilder.RenameColumn(
                name: "LeagueId",
                table: "TeamStats",
                newName: "LeagueSeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamStats_LeagueId",
                table: "TeamStats",
                newName: "IX_TeamStats_LeagueSeasonId");

            migrationBuilder.RenameColumn(
                name: "LeagueId",
                table: "RefereeStats",
                newName: "LeagueSeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_RefereeStats_LeagueId",
                table: "RefereeStats",
                newName: "IX_RefereeStats_LeagueSeasonId");

            migrationBuilder.RenameColumn(
                name: "LeagueId",
                table: "Matches",
                newName: "LeagueSeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_LeagueId",
                table: "Matches",
                newName: "IX_Matches_LeagueSeasonId");

            migrationBuilder.RenameColumn(
                name: "LeagueId",
                table: "FootballerStats",
                newName: "LeagueSeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_FootballerStats_LeagueId",
                table: "FootballerStats",
                newName: "IX_FootballerStats_LeagueSeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballerStats_LeagueSeasons_LeagueSeasonId",
                table: "FootballerStats",
                column: "LeagueSeasonId",
                principalTable: "LeagueSeasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_LeagueSeasons_LeagueSeasonId",
                table: "Matches",
                column: "LeagueSeasonId",
                principalTable: "LeagueSeasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefereeStats_LeagueSeasons_LeagueSeasonId",
                table: "RefereeStats",
                column: "LeagueSeasonId",
                principalTable: "LeagueSeasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamStats_LeagueSeasons_LeagueSeasonId",
                table: "TeamStats",
                column: "LeagueSeasonId",
                principalTable: "LeagueSeasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballerStats_LeagueSeasons_LeagueSeasonId",
                table: "FootballerStats");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_LeagueSeasons_LeagueSeasonId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_RefereeStats_LeagueSeasons_LeagueSeasonId",
                table: "RefereeStats");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamStats_LeagueSeasons_LeagueSeasonId",
                table: "TeamStats");

            migrationBuilder.RenameColumn(
                name: "LeagueSeasonId",
                table: "TeamStats",
                newName: "LeagueId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamStats_LeagueSeasonId",
                table: "TeamStats",
                newName: "IX_TeamStats_LeagueId");

            migrationBuilder.RenameColumn(
                name: "LeagueSeasonId",
                table: "RefereeStats",
                newName: "LeagueId");

            migrationBuilder.RenameIndex(
                name: "IX_RefereeStats_LeagueSeasonId",
                table: "RefereeStats",
                newName: "IX_RefereeStats_LeagueId");

            migrationBuilder.RenameColumn(
                name: "LeagueSeasonId",
                table: "Matches",
                newName: "LeagueId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_LeagueSeasonId",
                table: "Matches",
                newName: "IX_Matches_LeagueId");

            migrationBuilder.RenameColumn(
                name: "LeagueSeasonId",
                table: "FootballerStats",
                newName: "LeagueId");

            migrationBuilder.RenameIndex(
                name: "IX_FootballerStats_LeagueSeasonId",
                table: "FootballerStats",
                newName: "IX_FootballerStats_LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballerStats_LeagueSeasons_LeagueId",
                table: "FootballerStats",
                column: "LeagueId",
                principalTable: "LeagueSeasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_LeagueSeasons_LeagueId",
                table: "Matches",
                column: "LeagueId",
                principalTable: "LeagueSeasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefereeStats_LeagueSeasons_LeagueId",
                table: "RefereeStats",
                column: "LeagueId",
                principalTable: "LeagueSeasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamStats_LeagueSeasons_LeagueId",
                table: "TeamStats",
                column: "LeagueId",
                principalTable: "LeagueSeasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
