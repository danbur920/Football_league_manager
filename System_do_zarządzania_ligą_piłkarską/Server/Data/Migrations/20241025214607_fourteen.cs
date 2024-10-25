using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace System_do_zarządzania_ligą_piłkarską.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class fourteen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeagueSeasons_AspNetUsers_LeagueMasterId",
                table: "LeagueSeasons");

            migrationBuilder.RenameColumn(
                name: "LeagueMasterId",
                table: "LeagueSeasons",
                newName: "LeagueMasterSecondaryId");

            migrationBuilder.RenameIndex(
                name: "IX_LeagueSeasons_LeagueMasterId",
                table: "LeagueSeasons",
                newName: "IX_LeagueSeasons_LeagueMasterSecondaryId");

            migrationBuilder.AddColumn<string>(
                name: "LeagueMasterPrimaryId",
                table: "LeagueInfos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeagueInfos_LeagueMasterPrimaryId",
                table: "LeagueInfos",
                column: "LeagueMasterPrimaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeagueInfos_AspNetUsers_LeagueMasterPrimaryId",
                table: "LeagueInfos",
                column: "LeagueMasterPrimaryId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeagueSeasons_AspNetUsers_LeagueMasterSecondaryId",
                table: "LeagueSeasons",
                column: "LeagueMasterSecondaryId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeagueInfos_AspNetUsers_LeagueMasterPrimaryId",
                table: "LeagueInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_LeagueSeasons_AspNetUsers_LeagueMasterSecondaryId",
                table: "LeagueSeasons");

            migrationBuilder.DropIndex(
                name: "IX_LeagueInfos_LeagueMasterPrimaryId",
                table: "LeagueInfos");

            migrationBuilder.DropColumn(
                name: "LeagueMasterPrimaryId",
                table: "LeagueInfos");

            migrationBuilder.RenameColumn(
                name: "LeagueMasterSecondaryId",
                table: "LeagueSeasons",
                newName: "LeagueMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_LeagueSeasons_LeagueMasterSecondaryId",
                table: "LeagueSeasons",
                newName: "IX_LeagueSeasons_LeagueMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeagueSeasons_AspNetUsers_LeagueMasterId",
                table: "LeagueSeasons",
                column: "LeagueMasterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
