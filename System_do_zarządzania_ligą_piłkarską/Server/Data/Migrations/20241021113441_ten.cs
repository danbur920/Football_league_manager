using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace System_do_zarządzania_ligą_piłkarską.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class ten : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Leagues");

            migrationBuilder.AddColumn<int>(
                name: "LeagueInfoId",
                table: "Leagues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LeagueInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_LeagueInfoId",
                table: "Leagues",
                column: "LeagueInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leagues_LeagueInfo_LeagueInfoId",
                table: "Leagues",
                column: "LeagueInfoId",
                principalTable: "LeagueInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leagues_LeagueInfo_LeagueInfoId",
                table: "Leagues");

            migrationBuilder.DropTable(
                name: "LeagueInfo");

            migrationBuilder.DropIndex(
                name: "IX_Leagues_LeagueInfoId",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "LeagueInfoId",
                table: "Leagues");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Leagues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Leagues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Leagues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
