using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsToIaChat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "hash_source",
                schema: "public",
                table: "ia_chat",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "hash_source_type",
                schema: "public",
                table: "ia_chat",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hash_source",
                schema: "public",
                table: "ia_chat");

            migrationBuilder.DropColumn(
                name: "hash_source_type",
                schema: "public",
                table: "ia_chat");
        }
    }
}
