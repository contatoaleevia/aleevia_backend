using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProfessional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "professional",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    OfficeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    cpf = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    website = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    instagram = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    linkedin = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    doctoralia = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    biography = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    picture_url = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    google_token = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    google_refresh_token = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    PreRegister = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professional", x => x.id);
                    table.ForeignKey(
                        name: "FK_professional_office_OfficeId",
                        column: x => x.OfficeId,
                        principalSchema: "public",
                        principalTable: "office",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_professional_user_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "offices_professionals",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OfficeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfessionalId = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_professional_OfficeId",
                schema: "public",
                table: "professional",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_professional_UserId",
                schema: "public",
                table: "professional",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "offices_professionals",
                schema: "public");

            migrationBuilder.DropTable(
                name: "professional",
                schema: "public");
        }
    }
}
