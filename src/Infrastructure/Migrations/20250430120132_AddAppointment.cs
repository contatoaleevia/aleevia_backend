using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_addresses_user_SourceId",
                schema: "public",
                table: "addresses");

            migrationBuilder.DropIndex(
                name: "IX_addresses_SourceId",
                schema: "public",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "SourceId",
                schema: "public",
                table: "addresses");

            migrationBuilder.RenameColumn(
                name: "source_type",
                schema: "public",
                table: "addresses",
                newName: "SourceType_UserTypeId");

            migrationBuilder.CreateTable(
                name: "appointment",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfessionalId = table.Column<Guid>(type: "uuid", nullable: false),
                    OfficeId = table.Column<Guid>(type: "uuid", nullable: false),
                    AppointmentAddressId = table.Column<Guid>(type: "uuid", nullable: true),
                    appointment_type = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    date = table.Column<DateTime>(type: "timestamp", nullable: false),
                    appointment_status = table.Column<int>(type: "integer", nullable: false),
                    PatientCalendarEventId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProfessionalCalendarEventId = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => x.id);
                    table.ForeignKey(
                        name: "FK_appointment_office_OfficeId",
                        column: x => x.OfficeId,
                        principalSchema: "public",
                        principalTable: "office",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_appointment_user_PatientCalendarEventId",
                        column: x => x.PatientCalendarEventId,
                        principalSchema: "public",
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_appointment_user_ProfessionalCalendarEventId",
                        column: x => x.ProfessionalCalendarEventId,
                        principalSchema: "public",
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "appointment_address",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment_address", x => x.id);
                    table.ForeignKey(
                        name: "FK_appointment_address_addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "public",
                        principalTable: "addresses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_appointment_address_appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalSchema: "public",
                        principalTable: "appointment",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointment_AppointmentAddressId",
                schema: "public",
                table: "appointment",
                column: "AppointmentAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_OfficeId",
                schema: "public",
                table: "appointment",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_PatientCalendarEventId",
                schema: "public",
                table: "appointment",
                column: "PatientCalendarEventId");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_ProfessionalCalendarEventId",
                schema: "public",
                table: "appointment",
                column: "ProfessionalCalendarEventId");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_address_AddressId",
                schema: "public",
                table: "appointment_address",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_address_AppointmentId",
                schema: "public",
                table: "appointment_address",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_appointment_appointment_address_AppointmentAddressId",
                schema: "public",
                table: "appointment",
                column: "AppointmentAddressId",
                principalSchema: "public",
                principalTable: "appointment_address",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointment_appointment_address_AppointmentAddressId",
                schema: "public",
                table: "appointment");

            migrationBuilder.DropTable(
                name: "appointment_address",
                schema: "public");

            migrationBuilder.DropTable(
                name: "appointment",
                schema: "public");

            migrationBuilder.RenameColumn(
                name: "SourceType_UserTypeId",
                schema: "public",
                table: "addresses",
                newName: "source_type");

            migrationBuilder.AddColumn<Guid>(
                name: "SourceId",
                schema: "public",
                table: "addresses",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_addresses_SourceId",
                schema: "public",
                table: "addresses",
                column: "SourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_addresses_user_SourceId",
                schema: "public",
                table: "addresses",
                column: "SourceId",
                principalSchema: "public",
                principalTable: "user",
                principalColumn: "id");
        }
    }
}
