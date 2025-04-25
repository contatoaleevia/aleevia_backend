using Domain.Utils;
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
            var adminRole = RoleUtils.Admin;
            var patientRole = RoleUtils.Patient;
            var employerRole = RoleUtils.Employer;
            
            var sql = @$"
INSERT INTO public.identity_role (""Id"", ""Name"", ""NormalizedName"", ""ConcurrencyStamp"")
VALUES ('{adminRole.Id}', '{adminRole.Name}', '{adminRole.NormalizedName}', {adminRole.ConcurrencyStamp ?? "null"});

INSERT INTO public.identity_role (""Id"", ""Name"", ""NormalizedName"", ""ConcurrencyStamp"")
VALUES ('{patientRole.Id}', '{patientRole.Name}', '{patientRole.NormalizedName}', {patientRole.ConcurrencyStamp ?? "null"});

INSERT INTO public.identity_role (""Id"", ""Name"", ""NormalizedName"", ""ConcurrencyStamp"")
VALUES ('{employerRole.Id}', '{employerRole.Name}', '{employerRole.NormalizedName}', {employerRole.ConcurrencyStamp ?? "null"});";
            
            migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var adminRole = RoleUtils.Admin;
            var patientRole = RoleUtils.Patient;
            var employerRole = RoleUtils.Employer;
            
            var sql = @$"
DELETE
FROM public.identity_role
WHERE ""Id"" = '{adminRole.Id}';

DELETE
FROM public.identity_role
WHERE ""Id"" = '{patientRole.Id}';

DELETE
FROM public.identity_role
WHERE ""Id"" = '{employerRole.Id}';";
            
            migrationBuilder.Sql(sql);
        }
    }
}
