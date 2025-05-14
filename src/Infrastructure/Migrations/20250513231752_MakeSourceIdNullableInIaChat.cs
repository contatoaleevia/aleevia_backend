using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeSourceIdNullableInIaChat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ia_chat_user_SourceId",
                schema: "public",
                table: "ia_chat");

            migrationBuilder.DropIndex(
                name: "IX_ia_chat_SourceId",
                schema: "public",
                table: "ia_chat");

            migrationBuilder.RenameColumn(
                name: "SourceId",
                schema: "public",
                table: "ia_chat",
                newName: "source_id");

            migrationBuilder.AlterColumn<Guid>(
                name: "source_id",
                schema: "public",
                table: "ia_chat",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "source_id",
                schema: "public",
                table: "ia_chat",
                newName: "SourceId");

            migrationBuilder.AlterColumn<Guid>(
                name: "SourceId",
                schema: "public",
                table: "ia_chat",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ia_chat_SourceId",
                schema: "public",
                table: "ia_chat",
                column: "SourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ia_chat_user_SourceId",
                schema: "public",
                table: "ia_chat",
                column: "SourceId",
                principalSchema: "public",
                principalTable: "user",
                principalColumn: "id");
        }
    }
}
