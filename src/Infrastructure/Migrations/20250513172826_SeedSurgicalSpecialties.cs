using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedSurgicalSpecialties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var surgicalSpecialties = new[]
            {
                "Cirurgião Geral",
                "Cirurgião Cardíaco",
                "Cirurgião Torácico",
                "Cirurgião Pediátrico",
                "Cirurgião Plástico",
                "Neurocirurgião",
                "Cirurgião de Cabeça e Pescoço",
                "Cirurgião Oncológico"
            };

            var insertSql = @"
                INSERT INTO public.specialties (""Id"", name, active, created_at, profession_id)
                VALUES ({0}, {1}, true, {2}, (SELECT ""Id"" FROM public.professions WHERE name = 'Médico' LIMIT 1))";

            foreach (var specialty in surgicalSpecialties)
            {
                migrationBuilder.Sql(string.Format(insertSql,
                    $"'{Guid.NewGuid()}'",
                    $"'{specialty}'",
                    $"'{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss.fff}'"
                ));
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            foreach (var specialty in new[] {
                "Cirurgião Geral",
                "Cirurgião Cardíaco",
                "Cirurgião Torácico",
                "Cirurgião Pediátrico",
                "Cirurgião Plástico",
                "Neurocirurgião",
                "Cirurgião de Cabeça e Pescoço",
                "Cirurgião Oncológico"
            })
            {
                migrationBuilder.DeleteData(
                    schema: "public",
                    table: "specialties",
                    keyColumn: "name",
                    keyValue: specialty
                );
            }
        }
    }
}
