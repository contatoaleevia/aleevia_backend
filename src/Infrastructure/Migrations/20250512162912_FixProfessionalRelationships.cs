using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixProfessionalRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_professional_documents_professional_ProfessionalId1",
                schema: "public",
                table: "professional_documents");

            migrationBuilder.DropForeignKey(
                name: "FK_professional_specialty_details_professional_ProfessionalId1",
                schema: "public",
                table: "professional_specialty_details");

            migrationBuilder.DropIndex(
                name: "IX_professional_specialty_details_ProfessionalId1",
                schema: "public",
                table: "professional_specialty_details");

            migrationBuilder.DropIndex(
                name: "IX_professional_documents_ProfessionalId1",
                schema: "public",
                table: "professional_documents");

            migrationBuilder.DropColumn(
                name: "ProfessionalId1",
                schema: "public",
                table: "professional_specialty_details");

            migrationBuilder.DropColumn(
                name: "ProfessionalId1",
                schema: "public",
                table: "professional_documents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProfessionalId1",
                schema: "public",
                table: "professional_specialty_details",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessionalId1",
                schema: "public",
                table: "professional_documents",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_professional_specialty_details_ProfessionalId1",
                schema: "public",
                table: "professional_specialty_details",
                column: "ProfessionalId1");

            migrationBuilder.CreateIndex(
                name: "IX_professional_documents_ProfessionalId1",
                schema: "public",
                table: "professional_documents",
                column: "ProfessionalId1");

            migrationBuilder.AddForeignKey(
                name: "FK_professional_documents_professional_ProfessionalId1",
                schema: "public",
                table: "professional_documents",
                column: "ProfessionalId1",
                principalSchema: "public",
                principalTable: "professional",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_professional_specialty_details_professional_ProfessionalId1",
                schema: "public",
                table: "professional_specialty_details",
                column: "ProfessionalId1",
                principalSchema: "public",
                principalTable: "professional",
                principalColumn: "id");
        }
    }
}
