using Microsoft.EntityFrameworkCore.Migrations;

namespace ToHDL.Migrations
{
    public partial class RelationshipFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_SuperPowers_SuperPowerId",
                table: "Heroes");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_SuperPowerId",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "SuperPowerId",
                table: "Heroes");

            migrationBuilder.AddColumn<int>(
                name: "HeroId",
                table: "SuperPowers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SuperPowers_HeroId",
                table: "SuperPowers",
                column: "HeroId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SuperPowers_Heroes_HeroId",
                table: "SuperPowers",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperPowers_Heroes_HeroId",
                table: "SuperPowers");

            migrationBuilder.DropIndex(
                name: "IX_SuperPowers_HeroId",
                table: "SuperPowers");

            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "SuperPowers");

            migrationBuilder.AddColumn<int>(
                name: "SuperPowerId",
                table: "Heroes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_SuperPowerId",
                table: "Heroes",
                column: "SuperPowerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_SuperPowers_SuperPowerId",
                table: "Heroes",
                column: "SuperPowerId",
                principalTable: "SuperPowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
