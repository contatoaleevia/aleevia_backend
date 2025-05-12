using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProfessionalSpecialtyDetailsAndDocuments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "professional_documents",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    professional_id = table.Column<Guid>(type: "uuid", nullable: false),
                    document_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    document_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    document_state = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    front_url = table.Column<string>(type: "text", nullable: true),
                    back_url = table.Column<string>(type: "text", nullable: true),
                    validated = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    removed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ProfessionalId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professional_documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_professional_documents_professional_ProfessionalId1",
                        column: x => x.ProfessionalId1,
                        principalSchema: "public",
                        principalTable: "professional",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_professional_documents_professional_professional_id",
                        column: x => x.professional_id,
                        principalSchema: "public",
                        principalTable: "professional",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "professional_specialty_details",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    professional_id = table.Column<Guid>(type: "uuid", nullable: false),
                    profession_id = table.Column<Guid>(type: "uuid", nullable: false),
                    speciality_id = table.Column<Guid>(type: "uuid", nullable: false),
                    subspeciality_id = table.Column<Guid>(type: "uuid", nullable: true),
                    video_presentation = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    removed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ProfessionalId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professional_specialty_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_professional_specialty_details_professional_ProfessionalId1",
                        column: x => x.ProfessionalId1,
                        principalSchema: "public",
                        principalTable: "professional",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_professional_specialty_details_professional_professional_id",
                        column: x => x.professional_id,
                        principalSchema: "public",
                        principalTable: "professional",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_professional_specialty_details_professions_profession_id",
                        column: x => x.profession_id,
                        principalSchema: "public",
                        principalTable: "professions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_professional_specialty_details_specialties_speciality_id",
                        column: x => x.speciality_id,
                        principalSchema: "public",
                        principalTable: "specialties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_professional_specialty_details_sub_specialties_subspecialit~",
                        column: x => x.subspeciality_id,
                        principalSchema: "public",
                        principalTable: "sub_specialties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_professional_documents_professional_id",
                schema: "public",
                table: "professional_documents",
                column: "professional_id");

            migrationBuilder.CreateIndex(
                name: "IX_professional_documents_ProfessionalId1",
                schema: "public",
                table: "professional_documents",
                column: "ProfessionalId1");

            migrationBuilder.CreateIndex(
                name: "IX_professional_specialty_details_profession_id",
                schema: "public",
                table: "professional_specialty_details",
                column: "profession_id");

            migrationBuilder.CreateIndex(
                name: "IX_professional_specialty_details_professional_id",
                schema: "public",
                table: "professional_specialty_details",
                column: "professional_id");

            migrationBuilder.CreateIndex(
                name: "IX_professional_specialty_details_ProfessionalId1",
                schema: "public",
                table: "professional_specialty_details",
                column: "ProfessionalId1");

            migrationBuilder.CreateIndex(
                name: "IX_professional_specialty_details_speciality_id",
                schema: "public",
                table: "professional_specialty_details",
                column: "speciality_id");

            migrationBuilder.CreateIndex(
                name: "IX_professional_specialty_details_subspeciality_id",
                schema: "public",
                table: "professional_specialty_details",
                column: "subspeciality_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "professional_documents",
                schema: "public");

            migrationBuilder.DropTable(
                name: "professional_specialty_details",
                schema: "public");
        }
    }
}
