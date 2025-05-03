using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateChatAndMessageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ia_chat",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    source_type = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ia_chat", x => x.id);
                    table.ForeignKey(
                        name: "FK_ia_chat_user_SourceId",
                        column: x => x.SourceId,
                        principalSchema: "public",
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ia_message",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    IaChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    sender_type = table.Column<int>(type: "integer", nullable: false),
                    message = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ia_message", x => x.id);
                    table.ForeignKey(
                        name: "FK_ia_message_ia_chat_IaChatId",
                        column: x => x.IaChatId,
                        principalSchema: "public",
                        principalTable: "ia_chat",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ia_chat_SourceId",
                schema: "public",
                table: "ia_chat",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ia_message_IaChatId",
                schema: "public",
                table: "ia_message",
                column: "IaChatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ia_message",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ia_chat",
                schema: "public");
        }
    }
}
