using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProfessionalAndOfficeProfessional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_professional_office_OfficeId",
                schema: "public",
                table: "professional");

            migrationBuilder.DropForeignKey(
                name: "FK_professional_user_UserId",
                schema: "public",
                table: "professional");

            migrationBuilder.DropIndex(
                name: "IX_professional_OfficeId",
                schema: "public",
                table: "professional");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                schema: "public",
                table: "professional");

            migrationBuilder.DropColumn(
                name: "PreRegister",
                schema: "public",
                table: "professional");

            migrationBuilder.DropColumn(
                name: "doctoralia",
                schema: "public",
                table: "professional");

            migrationBuilder.DropColumn(
                name: "google_refresh_token",
                schema: "public",
                table: "professional");

            migrationBuilder.DropColumn(
                name: "google_token",
                schema: "public",
                table: "professional");

            migrationBuilder.DropColumn(
                name: "linkedin",
                schema: "public",
                table: "professional");

            migrationBuilder.RenameColumn(
                name: "picture_url",
                schema: "public",
                table: "professional",
                newName: "cnpj");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "public",
                table: "professional",
                newName: "manager_id");

            migrationBuilder.RenameColumn(
                name: "Active",
                schema: "public",
                table: "professional",
                newName: "is_registered");

            migrationBuilder.RenameIndex(
                name: "IX_professional_UserId",
                schema: "public",
                table: "professional",
                newName: "IX_professional_manager_id");

            migrationBuilder.AlterColumn<string>(
                name: "cnpj",
                schema: "public",
                table: "professional",
                type: "character varying(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_professional_manager_manager_id",
                schema: "public",
                table: "professional",
                column: "manager_id",
                principalSchema: "public",
                principalTable: "manager",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_professional_manager_manager_id",
                schema: "public",
                table: "professional");

            migrationBuilder.RenameColumn(
                name: "cnpj",
                schema: "public",
                table: "professional",
                newName: "picture_url");

            migrationBuilder.RenameColumn(
                name: "manager_id",
                schema: "public",
                table: "professional",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "is_registered",
                schema: "public",
                table: "professional",
                newName: "Active");

            migrationBuilder.RenameIndex(
                name: "IX_professional_manager_id",
                schema: "public",
                table: "professional",
                newName: "IX_professional_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "picture_url",
                schema: "public",
                table: "professional",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(14)",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OfficeId",
                schema: "public",
                table: "professional",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "PreRegister",
                schema: "public",
                table: "professional",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "doctoralia",
                schema: "public",
                table: "professional",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "google_refresh_token",
                schema: "public",
                table: "professional",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "google_token",
                schema: "public",
                table: "professional",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "linkedin",
                schema: "public",
                table: "professional",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_professional_OfficeId",
                schema: "public",
                table: "professional",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_professional_office_OfficeId",
                schema: "public",
                table: "professional",
                column: "OfficeId",
                principalSchema: "public",
                principalTable: "office",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_professional_user_UserId",
                schema: "public",
                table: "professional",
                column: "UserId",
                principalSchema: "public",
                principalTable: "user",
                principalColumn: "id");
        }
    }
}
