using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace System_do_zarządzania_ligą_piłkarską.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class eleven : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballerStats_Leagues_LeagueId",
                table: "FootballerStats");

            migrationBuilder.DropForeignKey(
                name: "FK_Leagues_LeagueInfo_LeagueInfoId",
                table: "Leagues");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Leagues_LeagueId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_RefereeStats_Leagues_LeagueId",
                table: "RefereeStats");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamStats_Leagues_LeagueId",
                table: "TeamStats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leagues",
                table: "Leagues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeagueInfo",
                table: "LeagueInfo");

            migrationBuilder.RenameTable(
                name: "Leagues",
                newName: "LeagueSeasons");

            migrationBuilder.RenameTable(
                name: "LeagueInfo",
                newName: "LeagueInfos");

            migrationBuilder.RenameIndex(
                name: "IX_Leagues_LeagueInfoId",
                table: "LeagueSeasons",
                newName: "IX_LeagueSeasons_LeagueInfoId");

            migrationBuilder.AlterColumn<int>(
                name: "Season",
                table: "LeagueSeasons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeagueSeasons",
                table: "LeagueSeasons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeagueInfos",
                table: "LeagueInfos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballerStats_LeagueSeasons_LeagueId",
                table: "FootballerStats",
                column: "LeagueId",
                principalTable: "LeagueSeasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeagueSeasons_LeagueInfos_LeagueInfoId",
                table: "LeagueSeasons",
                column: "LeagueInfoId",
                principalTable: "LeagueInfos",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballerStats_LeagueSeasons_LeagueId",
                table: "FootballerStats");

            migrationBuilder.DropForeignKey(
                name: "FK_LeagueSeasons_LeagueInfos_LeagueInfoId",
                table: "LeagueSeasons");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_LeagueSeasons_LeagueId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_RefereeStats_LeagueSeasons_LeagueId",
                table: "RefereeStats");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamStats_LeagueSeasons_LeagueId",
                table: "TeamStats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeagueSeasons",
                table: "LeagueSeasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeagueInfos",
                table: "LeagueInfos");

            migrationBuilder.RenameTable(
                name: "LeagueSeasons",
                newName: "Leagues");

            migrationBuilder.RenameTable(
                name: "LeagueInfos",
                newName: "LeagueInfo");

            migrationBuilder.RenameIndex(
                name: "IX_LeagueSeasons_LeagueInfoId",
                table: "Leagues",
                newName: "IX_Leagues_LeagueInfoId");

            migrationBuilder.AlterColumn<string>(
                name: "Season",
                table: "Leagues",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leagues",
                table: "Leagues",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeagueInfo",
                table: "LeagueInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballerStats_Leagues_LeagueId",
                table: "FootballerStats",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Leagues_LeagueInfo_LeagueInfoId",
                table: "Leagues",
                column: "LeagueInfoId",
                principalTable: "LeagueInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Leagues_LeagueId",
                table: "Matches",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefereeStats_Leagues_LeagueId",
                table: "RefereeStats",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamStats_Leagues_LeagueId",
                table: "TeamStats",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
