using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOfficeProfessional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "offices_professionals",
                schema: "public");

            migrationBuilder.CreateTable(
                name: "offices_professional",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    office_id = table.Column<Guid>(type: "uuid", nullable: false),
                    professional_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_public = table.Column<bool>(type: "boolean", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offices_professional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_offices_professional_office_office_id",
                        column: x => x.office_id,
                        principalSchema: "public",
                        principalTable: "office",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_offices_professional_professional_professional_id",
                        column: x => x.professional_id,
                        principalSchema: "public",
                        principalTable: "professional",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_offices_professional_office_id",
                schema: "public",
                table: "offices_professional",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_offices_professional_professional_id",
                schema: "public",
                table: "offices_professional",
                column: "professional_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "offices_professional",
                schema: "public");

            migrationBuilder.CreateTable(
                name: "offices_professionals",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OfficeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfessionalId = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offices_professionals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_offices_professionals_office_OfficeId",
                        column: x => x.OfficeId,
                        principalSchema: "public",
                        principalTable: "office",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_offices_professionals_professional_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalSchema: "public",
                        principalTable: "professional",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_offices_professionals_OfficeId",
                schema: "public",
                table: "offices_professionals",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_offices_professionals_ProfessionalId",
                schema: "public",
                table: "offices_professionals",
                column: "ProfessionalId");
        }
    }
}
