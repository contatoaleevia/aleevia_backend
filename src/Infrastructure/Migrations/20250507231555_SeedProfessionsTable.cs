using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedProfessionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var professions_data = new Dictionary<string, Dictionary<string, string[]>>
            {
                {
                    "Médico", new Dictionary<string, string[]>
                    {
                        {"Clínico Geral", new[] {"Medicina Preventiva", "Medicina Ambulatorial"}},
                        {"Médico da Família", new[] {"Saúde da Família", "Atenção Primária"}},
                        {"Pediatra", new[] {"Neonatologia", "Alergia Pediátrica", "Endocrinopediatria"}},
                        {"Cardiologista", new[] {"Eletrofisiologia", "Hemodinâmica", "Insuficiência Cardíaca"}},
                        {"Dermatologista", new[] {"Dermatologia Estética", "Dermatopatologia", "Cirurgia Dermatológica"}},
                        {"Endocrinologista", new[] {"Endocrinopediatria", "Diabetes", "Obesidade", "Tireoide"}},
                        {"Neurologista", new[] {"Neurovascular", "Epilepsia", "Neuroimunologia", "Neurologia Pediátrica"}},
                        {"Ortopedista", new[] {"Ortopedia Pediátrica", "Cirurgia da Coluna", "Medicina Esportiva"}},
                        {"Ginecologista", new[] {"Obstetrícia", "Reprodução Humana", "Uroginecologia"}},
                        {"Psiquiatra", new[] {"Psiquiatria Infantil", "Psicogeriatria", "Dependência Química"}},
                        {"Oftalmologista", new[] {"Retina", "Glaucoma", "Córnea", "Cirurgia Refrativa"}},
                        {"Otorrinolaringologista", new[] {"Otologia", "Rinologia", "Otoneurologia", "Cirurgia de Cabeça e Pescoço"}},
                        {"Urologista", new[] {"Urologia Pediátrica", "Andrologia", "Oncologia Urológica"}},
                        {"Nefrologista", new[] {"Nefropediatria", "Hemodiálise", "Transplante Renal"}},
                        {"Pneumologista", new[] {"Pneumologia Pediátrica", "Sono", "DPOC"}},
                        {"Reumatologista", new[] {"Reumatologia Pediátrica", "Doenças Autoimunes", "Osteoporose"}},
                        {"Geriatra", new[] {"Cuidados Paliativos", "Neurogeriatria", "Avaliação Multidimensional"}},
                        {"Gastroenterologista", new[] {"Hepatologia", "Endoscopia Digestiva", "Gastroenterologia Pediátrica"}}
                    }
                },
                {
                    "Enfermeiro", new Dictionary<string, string[]>
                    {
                        {"Enfermeiro", new[] {"Obstétrica", "Pediátrica", "Geriátrica", "UTI"}}
                    }
                },
                {
                    "Técnico de Enfermagem", new Dictionary<string, string[]>
                    {
                        {"Técnico de Enfermagem", new[] {"Centro Cirúrgico", "UTI", "Domiciliar"}}
                    }
                },
                {
                    "Nutricionista", new Dictionary<string, string[]>
                    {
                        {"Nutricionista", new[] {"Esportiva", "Clínica", "Infantil", "Funcional"}}
                    }
                },
                {
                    "Psicólogo", new Dictionary<string, string[]>
                    {
                        {"Psicólogo", new[] {"Clínica", "Organizacional", "Neuropsicologia", "Psicopedagogia"}}
                    }
                },
                {
                    "Fisioterapeuta", new Dictionary<string, string[]>
                    {
                        {"Fisioterapeuta", new[] {"Respiratória", "Ortopédica", "Neurológica", "Pélvica"}}
                    }
                },
                {
                    "Terapeuta Ocupacional", new Dictionary<string, string[]>
                    {
                        {"Terapeuta Ocupacional", new[] {"Saúde Mental", "Reabilitação Física", "Pediatria", "Gerontologia"}}
                    }
                },
                {
                    "Fonoaudiólogo", new Dictionary<string, string[]>
                    {
                        {"Fonoaudiólogo", new[] {"Linguagem", "Motricidade Orofacial", "Voz", "Audiologia"}}
                    }
                },
                {
                    "Biomédico", new Dictionary<string, string[]>
                    {
                        {"Biomédico", new[] {"Estética", "Análises Clínicas", "Imagenologia", "Genética"}}
                    }
                },
                {
                    "Dentista", new Dictionary<string, string[]>
                    {
                        {"Dentista", new[] {"Ortodontia", "Endodontia", "Implantodontia", "Odontopediatria"}}
                    }
                },
                {
                    "Acupunturista", new Dictionary<string, string[]>
                    {
                        {"Acupunturista", new[] {"Dor Crônica", "Estética", "Ansiedade"}}
                    }
                },
                {
                    "Quiropraxista", new Dictionary<string, string[]>
                    {
                        {"Quiropraxista", new[] {"Coluna Vertebral", "Desportiva", "Reabilitação Funcional"}}
                    }
                },
                {
                    "Outros", new Dictionary<string, string[]>
                    {
                        {"Outros", new[] {"Outros"}}
                    }
                }
            };

            foreach (var profession in professions_data)
            {
                var professionId = Guid.NewGuid();
                migrationBuilder.InsertData(
                    schema: "public",
                    table: "professions",
                    columns: ["Id", "name", "active", "created_at"],
                    values: [professionId, profession.Key, true, DateTime.UtcNow]
                );

                foreach (var specialty in profession.Value)
                {
                    var specialtyId = Guid.NewGuid();
                    migrationBuilder.InsertData(
                        schema: "public",
                        table: "specialties",
                        columns: ["Id", "name", "active", "created_at", "profession_id"],
                        values: [specialtyId, specialty.Key, true, DateTime.UtcNow, professionId]
                    );

                    foreach (var subSpecialty in specialty.Value)
                    {
                        migrationBuilder.InsertData(
                            schema: "public",
                            table: "sub_specialties",
                            columns: new[] { "Id", "name", "active", "created_at", "specialty_id" },
                            values: new object[] { Guid.NewGuid(), subSpecialty, true, DateTime.UtcNow, specialtyId }
                        );
                    }
                }
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(schema: "public", table: "professions", keyColumn: "Active", keyValue: true);
        }

    }
}
