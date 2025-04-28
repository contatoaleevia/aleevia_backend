using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateFaq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_UserType_UserTypeId",
                schema: "public",
                table: "user");

            migrationBuilder.DropTable(
                name: "UserType",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_user_UserTypeId",
                schema: "public",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "UserTypeId",
                schema: "public",
                table: "user",
                newName: "type");

            migrationBuilder.CreateTable(
                name: "faq",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    source_type = table.Column<int>(type: "integer", nullable: false),
                    question = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    answer = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    faq_category = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faq", x => x.id);
                    table.ForeignKey(
                        name: "FK_faq_user_SourceId",
                        column: x => x.SourceId,
                        principalSchema: "public",
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_faq_SourceId",
                schema: "public",
                table: "faq",
                column: "SourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "faq",
                schema: "public");

            migrationBuilder.RenameColumn(
                name: "type",
                schema: "public",
                table: "user",
                newName: "UserTypeId");

            migrationBuilder.CreateTable(
                name: "UserType",
                schema: "public",
                columns: table => new
                {
                    UserTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_UserTypeId",
                schema: "public",
                table: "user",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_UserType_UserTypeId",
                schema: "public",
                table: "user",
                column: "UserTypeId",
                principalSchema: "public",
                principalTable: "UserType",
                principalColumn: "UserTypeId");
        }
    }
}
