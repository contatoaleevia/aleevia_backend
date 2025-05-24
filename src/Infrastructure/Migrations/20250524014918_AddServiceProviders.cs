using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceProviders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "service_providers",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    corporate_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    office_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_service_providers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_service_providers_office_office_id",
                        column: x => x.office_id,
                        principalSchema: "public",
                        principalTable: "office",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_service_providers_name",
                schema: "public",
                table: "service_providers",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_service_providers_office_id",
                schema: "public",
                table: "service_providers",
                column: "office_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "service_providers",
                schema: "public");
        }
    }
}
