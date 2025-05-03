using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateOfficeAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_addresses_user_SourceId",
                schema: "public",
                table: "addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_addresses",
                schema: "public",
                table: "addresses");

            migrationBuilder.RenameTable(
                name: "addresses",
                schema: "public",
                newName: "address",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "SourceId",
                schema: "public",
                table: "address",
                newName: "source_id");

            migrationBuilder.RenameIndex(
                name: "IX_addresses_SourceId",
                schema: "public",
                table: "address",
                newName: "IX_address_source_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_address",
                schema: "public",
                table: "address",
                column: "id");

            migrationBuilder.CreateTable(
                name: "office_address",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    address_id = table.Column<Guid>(type: "uuid", nullable: false),
                    office_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_office_address", x => x.id);
                    table.ForeignKey(
                        name: "FK_office_address_address_address_id",
                        column: x => x.address_id,
                        principalSchema: "public",
                        principalTable: "address",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_office_address_office_office_id",
                        column: x => x.office_id,
                        principalSchema: "public",
                        principalTable: "office",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_office_address_address_id_office_id",
                schema: "public",
                table: "office_address",
                columns: new[] { "address_id", "office_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_office_address_office_id",
                schema: "public",
                table: "office_address",
                column: "office_id");

            migrationBuilder.AddForeignKey(
                name: "FK_address_user_source_id",
                schema: "public",
                table: "address",
                column: "source_id",
                principalSchema: "public",
                principalTable: "user",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_user_source_id",
                schema: "public",
                table: "address");

            migrationBuilder.DropTable(
                name: "office_address",
                schema: "public");

            migrationBuilder.DropPrimaryKey(
                name: "PK_address",
                schema: "public",
                table: "address");

            migrationBuilder.RenameTable(
                name: "address",
                schema: "public",
                newName: "addresses",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "source_id",
                schema: "public",
                table: "addresses",
                newName: "SourceId");

            migrationBuilder.RenameIndex(
                name: "IX_address_source_id",
                schema: "public",
                table: "addresses",
                newName: "IX_addresses_SourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_addresses",
                schema: "public",
                table: "addresses",
                column: "id");

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
