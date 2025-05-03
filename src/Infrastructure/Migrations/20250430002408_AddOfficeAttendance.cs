using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOfficeAttendance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "office_attendance",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    office_id = table.Column<Guid>(type: "uuid", nullable: false),
                    service_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_office_attendance", x => x.id);
                    table.ForeignKey(
                        name: "FK_office_attendance_office_office_id",
                        column: x => x.office_id,
                        principalSchema: "public",
                        principalTable: "office",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_office_attendance_service_type_service_type_id",
                        column: x => x.service_type_id,
                        principalSchema: "public",
                        principalTable: "service_type",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_office_attendance_office_id",
                schema: "public",
                table: "office_attendance",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_office_attendance_service_type_id",
                schema: "public",
                table: "office_attendance",
                column: "service_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "office_attendance",
                schema: "public");
        }
    }
}
