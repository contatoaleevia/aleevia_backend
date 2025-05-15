using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateOfficeSpecialtiesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "office_specialty",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    office_id = table.Column<Guid>(type: "uuid", nullable: false),
                    specialty_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_office_specialty", x => x.id);
                    table.ForeignKey(
                        name: "FK_office_specialty_office_office_id",
                        column: x => x.office_id,
                        principalSchema: "public",
                        principalTable: "office",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_office_specialty_specialties_specialty_id",
                        column: x => x.specialty_id,
                        principalSchema: "public",
                        principalTable: "specialties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_office_specialty_office_id_specialty_id",
                schema: "public",
                table: "office_specialty",
                columns: new[] { "office_id", "specialty_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_office_specialty_specialty_id",
                schema: "public",
                table: "office_specialty",
                column: "specialty_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "office_specialty",
                schema: "public");
        }
    }
}
