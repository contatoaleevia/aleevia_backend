using Domain.Entities.Identities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InsertRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var adminRole = Role.Admin;
            var patientRole = Role.Patient;
            var employeeRole = Role.Employee;
            var professionalRole = Role.Professional;
            
            var sql = @$"
INSERT INTO public.role (""id"", ""name"", ""normalized_name"", ""concurrency_stamp"")
VALUES ('{adminRole.Id}', '{adminRole.Name}', '{adminRole.NormalizedName}', '{adminRole.ConcurrencyStamp}');

INSERT INTO public.role (""id"", ""name"", ""normalized_name"", ""concurrency_stamp"")
VALUES ('{patientRole.Id}', '{patientRole.Name}', '{patientRole.NormalizedName}', '{patientRole.ConcurrencyStamp}');

INSERT INTO public.role (""id"", ""name"", ""normalized_name"", ""concurrency_stamp"")
VALUES ('{employeeRole.Id}', '{employeeRole.Name}', '{employeeRole.NormalizedName}', '{employeeRole.ConcurrencyStamp}');

INSERT INTO public.role (""id"", ""name"", ""normalized_name"", ""concurrency_stamp"")
VALUES ('{professionalRole.Id}', '{professionalRole.Name}', '{professionalRole.NormalizedName}', '{professionalRole.ConcurrencyStamp}');";
            
            migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var adminRole = Role.Admin;
            var patientRole = Role.Patient;
            var employerRole = Role.Employee;
            
            var sql = @$"
DELETE
FROM public.role
WHERE ""Id"" = '{adminRole.Id}';

DELETE
FROM public.role
WHERE ""Id"" = '{patientRole.Id}';

DELETE
FROM public.role
WHERE ""Id"" = '{employerRole.Id}';";
            
            migrationBuilder.Sql(sql);
        }

    }
}
