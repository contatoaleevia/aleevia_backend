using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableOfficeAndUpdateUserCnpj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "cnpj",
                schema: "public",
                table: "user",
                type: "character varying(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(14)",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "office",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false, defaultValue: ""),
                    phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false, defaultValue: ""),
                    whatsapp = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false, defaultValue: ""),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    site = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    instagram = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    logo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_office", x => x.id);
                    table.ForeignKey(
                        name: "FK_office_manager_owner_id",
                        column: x => x.owner_id,
                        principalSchema: "public",
                        principalTable: "manager",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_office_owner_id",
                schema: "public",
                table: "office",
                column: "owner_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "office",
                schema: "public");

            migrationBuilder.AlterColumn<string>(
                name: "cnpj",
                schema: "public",
                table: "user",
                type: "character varying(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(14)",
                oldMaxLength: 14,
                oldDefaultValue: "");
        }
    }
}
