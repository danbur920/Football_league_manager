using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace System_do_zarządzania_ligą_piłkarską.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class twentyThree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeagueSeasonId",
                table: "Trophies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrophyId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_TrophyId",
                table: "Images",
                column: "TrophyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Trophies_TrophyId",
                table: "Images",
                column: "TrophyId",
                principalTable: "Trophies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Trophies_TrophyId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_TrophyId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "LeagueSeasonId",
                table: "Trophies");

            migrationBuilder.DropColumn(
                name: "TrophyId",
                table: "Images");
        }
    }
}
