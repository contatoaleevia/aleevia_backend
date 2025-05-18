using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProfessionalAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "professional_address",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfessionalId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professional_address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_professional_address_address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "public",
                        principalTable: "address",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_professional_address_professional_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalSchema: "public",
                        principalTable: "professional",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_professional_address_AddressId",
                schema: "public",
                table: "professional_address",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_professional_address_ProfessionalId",
                schema: "public",
                table: "professional_address",
                column: "ProfessionalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "professional_address",
                schema: "public");
        }
    }
}
