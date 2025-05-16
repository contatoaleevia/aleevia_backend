using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAiChatRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rating_chat",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    general = table.Column<int>(type: "integer", nullable: false),
                    experience = table.Column<int>(type: "integer", nullable: false),
                    utility = table.Column<int>(type: "integer", nullable: false),
                    problem_solved = table.Column<int>(type: "integer", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rating_chat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rating_chat_ia_chat_ChatId",
                        column: x => x.ChatId,
                        principalSchema: "public",
                        principalTable: "ia_chat",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_rating_chat_ChatId",
                schema: "public",
                table: "rating_chat",
                column: "ChatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rating_chat",
                schema: "public");
        }
    }
}
