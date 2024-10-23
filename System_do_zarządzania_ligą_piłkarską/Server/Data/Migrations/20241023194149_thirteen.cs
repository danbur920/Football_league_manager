using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace System_do_zarządzania_ligą_piłkarską.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class thirteen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Season",
                table: "LeagueSeasons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "LeagueMasterId",
                table: "LeagueSeasons",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeagueSeasons_LeagueMasterId",
                table: "LeagueSeasons",
                column: "LeagueMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeagueSeasons_AspNetUsers_LeagueMasterId",
                table: "LeagueSeasons",
                column: "LeagueMasterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeagueSeasons_AspNetUsers_LeagueMasterId",
                table: "LeagueSeasons");

            migrationBuilder.DropIndex(
                name: "IX_LeagueSeasons_LeagueMasterId",
                table: "LeagueSeasons");

            migrationBuilder.DropColumn(
                name: "LeagueMasterId",
                table: "LeagueSeasons");

            migrationBuilder.AlterColumn<string>(
                name: "Season",
                table: "LeagueSeasons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
