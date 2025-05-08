using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateProfessional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "profession_id",
                schema: "public",
                table: "professional",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_professional_profession_id",
                schema: "public",
                table: "professional",
                column: "profession_id");

            migrationBuilder.AddForeignKey(
                name: "FK_professional_professions_profession_id",
                schema: "public",
                table: "professional",
                column: "profession_id",
                principalSchema: "public",
                principalTable: "professions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_professional_professions_profession_id",
                schema: "public",
                table: "professional");

            migrationBuilder.DropIndex(
                name: "IX_professional_profession_id",
                schema: "public",
                table: "professional");

            migrationBuilder.DropColumn(
                name: "profession_id",
                schema: "public",
                table: "professional");
        }
    }
}
