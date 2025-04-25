using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAddress : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
