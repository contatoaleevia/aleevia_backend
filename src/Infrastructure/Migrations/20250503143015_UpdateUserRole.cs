using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_identity_user_role_identity_role_RoleId",
                schema: "public",
                table: "identity_user_role");

            migrationBuilder.DropForeignKey(
                name: "FK_identity_user_role_user_UserId",
                schema: "public",
                table: "identity_user_role");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                schema: "public",
                table: "identity_user_role",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "public",
                table: "identity_user_role",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_identity_user_role_RoleId",
                schema: "public",
                table: "identity_user_role",
                newName: "IX_identity_user_role_role_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "public",
                table: "identity_role",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "identity_role",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "NormalizedName",
                schema: "public",
                table: "identity_role",
                newName: "normalized_name");

            migrationBuilder.RenameColumn(
                name: "ConcurrencyStamp",
                schema: "public",
                table: "identity_role",
                newName: "concurrency_stamp");

            migrationBuilder.AlterColumn<long>(
                name: "price",
                schema: "public",
                table: "office_attendance",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "public",
                table: "identity_role",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "normalized_name",
                schema: "public",
                table: "identity_role",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "concurrency_stamp",
                schema: "public",
                table: "identity_role",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_identity_user_role_identity_role_role_id",
                schema: "public",
                table: "identity_user_role",
                column: "role_id",
                principalSchema: "public",
                principalTable: "identity_role",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_identity_user_role_user_user_id",
                schema: "public",
                table: "identity_user_role",
                column: "user_id",
                principalSchema: "public",
                principalTable: "user",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_identity_user_role_identity_role_role_id",
                schema: "public",
                table: "identity_user_role");

            migrationBuilder.DropForeignKey(
                name: "FK_identity_user_role_user_user_id",
                schema: "public",
                table: "identity_user_role");

            migrationBuilder.RenameColumn(
                name: "role_id",
                schema: "public",
                table: "identity_user_role",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "public",
                table: "identity_user_role",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_identity_user_role_role_id",
                schema: "public",
                table: "identity_user_role",
                newName: "IX_identity_user_role_RoleId");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "public",
                table: "identity_role",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "identity_role",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "normalized_name",
                schema: "public",
                table: "identity_role",
                newName: "NormalizedName");

            migrationBuilder.RenameColumn(
                name: "concurrency_stamp",
                schema: "public",
                table: "identity_role",
                newName: "ConcurrencyStamp");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                schema: "public",
                table: "office_attendance",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "public",
                table: "identity_role",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                schema: "public",
                table: "identity_role",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "public",
                table: "identity_role",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_identity_user_role_identity_role_RoleId",
                schema: "public",
                table: "identity_user_role",
                column: "RoleId",
                principalSchema: "public",
                principalTable: "identity_role",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_identity_user_role_user_UserId",
                schema: "public",
                table: "identity_user_role",
                column: "UserId",
                principalSchema: "public",
                principalTable: "user",
                principalColumn: "id");
        }
    }
}
