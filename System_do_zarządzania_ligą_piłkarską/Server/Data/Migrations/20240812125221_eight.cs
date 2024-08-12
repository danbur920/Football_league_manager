using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace System_do_zarządzania_ligą_piłkarską.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class eight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchEvent_Matches_MatchId",
                table: "MatchEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchEvent",
                table: "MatchEvent");

            migrationBuilder.RenameTable(
                name: "MatchEvent",
                newName: "MatchEvents");

            migrationBuilder.RenameIndex(
                name: "IX_MatchEvent_MatchId",
                table: "MatchEvents",
                newName: "IX_MatchEvents_MatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchEvents",
                table: "MatchEvents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchEvents_Matches_MatchId",
                table: "MatchEvents",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchEvents_Matches_MatchId",
                table: "MatchEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchEvents",
                table: "MatchEvents");

            migrationBuilder.RenameTable(
                name: "MatchEvents",
                newName: "MatchEvent");

            migrationBuilder.RenameIndex(
                name: "IX_MatchEvents_MatchId",
                table: "MatchEvent",
                newName: "IX_MatchEvent_MatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchEvent",
                table: "MatchEvent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchEvent_Matches_MatchId",
                table: "MatchEvent",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
