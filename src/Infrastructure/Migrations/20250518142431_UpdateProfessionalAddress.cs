using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProfessionalAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_professional_address_address_AddressId",
                schema: "public",
                table: "professional_address");

            migrationBuilder.DropForeignKey(
                name: "FK_professional_address_professional_ProfessionalId",
                schema: "public",
                table: "professional_address");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "professional_address",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProfessionalId",
                schema: "public",
                table: "professional_address",
                newName: "professional_id");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                schema: "public",
                table: "professional_address",
                newName: "address_id");

            migrationBuilder.RenameIndex(
                name: "IX_professional_address_ProfessionalId",
                schema: "public",
                table: "professional_address",
                newName: "IX_professional_address_professional_id");

            migrationBuilder.RenameIndex(
                name: "IX_professional_address_AddressId",
                schema: "public",
                table: "professional_address",
                newName: "IX_professional_address_address_id");

            migrationBuilder.AddForeignKey(
                name: "FK_professional_address_address_address_id",
                schema: "public",
                table: "professional_address",
                column: "address_id",
                principalSchema: "public",
                principalTable: "address",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_professional_address_professional_professional_id",
                schema: "public",
                table: "professional_address",
                column: "professional_id",
                principalSchema: "public",
                principalTable: "professional",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_professional_address_address_address_id",
                schema: "public",
                table: "professional_address");

            migrationBuilder.DropForeignKey(
                name: "FK_professional_address_professional_professional_id",
                schema: "public",
                table: "professional_address");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "professional_address",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "professional_id",
                schema: "public",
                table: "professional_address",
                newName: "ProfessionalId");

            migrationBuilder.RenameColumn(
                name: "address_id",
                schema: "public",
                table: "professional_address",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_professional_address_professional_id",
                schema: "public",
                table: "professional_address",
                newName: "IX_professional_address_ProfessionalId");

            migrationBuilder.RenameIndex(
                name: "IX_professional_address_address_id",
                schema: "public",
                table: "professional_address",
                newName: "IX_professional_address_AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_professional_address_address_AddressId",
                schema: "public",
                table: "professional_address",
                column: "AddressId",
                principalSchema: "public",
                principalTable: "address",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_professional_address_professional_ProfessionalId",
                schema: "public",
                table: "professional_address",
                column: "ProfessionalId",
                principalSchema: "public",
                principalTable: "professional",
                principalColumn: "id");
        }
    }
}
