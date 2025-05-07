using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFaqPage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_faq_user_SourceId",
                schema: "public",
                table: "faq");

            migrationBuilder.DropIndex(
                name: "IX_faq_SourceId",
                schema: "public",
                table: "faq");

            migrationBuilder.RenameColumn(
                name: "SourceId",
                schema: "public",
                table: "faq",
                newName: "source_id");

            migrationBuilder.CreateTable(
                name: "faq_page",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    source_id = table.Column<Guid>(type: "uuid", nullable: false),
                    custom_url = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    welcome_message = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faq_page", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_faq_page_custom_url",
                schema: "public",
                table: "faq_page",
                column: "custom_url",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "faq_page",
                schema: "public");

            migrationBuilder.RenameColumn(
                name: "source_id",
                schema: "public",
                table: "faq",
                newName: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_faq_SourceId",
                schema: "public",
                table: "faq",
                column: "SourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_faq_user_SourceId",
                schema: "public",
                table: "faq",
                column: "SourceId",
                principalSchema: "public",
                principalTable: "user",
                principalColumn: "id");
        }
    }
}
