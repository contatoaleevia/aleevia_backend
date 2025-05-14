START TRANSACTION;

CREATE TABLE public.office_specialty (
    id uuid NOT NULL,
    office_id uuid NOT NULL,
    specialty_id uuid NOT NULL,
    is_active boolean NOT NULL,
    CONSTRAINT "PK_office_specialty" PRIMARY KEY (id),
    CONSTRAINT "FK_office_specialty_office_office_id" FOREIGN KEY (office_id) REFERENCES public.office (id),
    CONSTRAINT "FK_office_specialty_specialties_specialty_id" FOREIGN KEY (specialty_id) REFERENCES public.specialties ("Id")
);

CREATE UNIQUE INDEX "IX_office_specialty_office_id_specialty_id" ON public.office_specialty (office_id, specialty_id);

CREATE INDEX "IX_office_specialty_specialty_id" ON public.office_specialty (specialty_id);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250513151649_CreateOfficeSpecialtiesTable', '8.0.15');

COMMIT;

START TRANSACTION;


                INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
                VALUES ('53f9e935-bed7-46d9-9b9f-d9d378dedf5c', 'Cirurgião Geral', true, '2025-05-14 00:45:57.257', (SELECT "Id" FROM public.professions WHERE name = 'Médico' LIMIT 1))


                INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
                VALUES ('2a739120-9e7f-48ac-8685-e6b05c90b4a6', 'Cirurgião Cardíaco', true, '2025-05-14 00:45:57.264', (SELECT "Id" FROM public.professions WHERE name = 'Médico' LIMIT 1))


                INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
                VALUES ('6fe1d05c-e842-4796-84ac-565e4f2371eb', 'Cirurgião Torácico', true, '2025-05-14 00:45:57.264', (SELECT "Id" FROM public.professions WHERE name = 'Médico' LIMIT 1))


                INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
                VALUES ('75e5d141-78f5-4c92-9c40-3f191aed55e5', 'Cirurgião Pediátrico', true, '2025-05-14 00:45:57.264', (SELECT "Id" FROM public.professions WHERE name = 'Médico' LIMIT 1))


                INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
                VALUES ('b797fba6-f9fe-4757-b267-542145adcc53', 'Cirurgião Plástico', true, '2025-05-14 00:45:57.264', (SELECT "Id" FROM public.professions WHERE name = 'Médico' LIMIT 1))


                INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
                VALUES ('26c1e964-0ab0-4c01-903f-47f0c792790d', 'Neurocirurgião', true, '2025-05-14 00:45:57.264', (SELECT "Id" FROM public.professions WHERE name = 'Médico' LIMIT 1))


                INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
                VALUES ('be2188b4-bd28-4fe3-b75e-b71687bbad96', 'Cirurgião de Cabeça e Pescoço', true, '2025-05-14 00:45:57.264', (SELECT "Id" FROM public.professions WHERE name = 'Médico' LIMIT 1))


                INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
                VALUES ('9cb4ee98-2471-44da-9d6a-7335b28402e9', 'Cirurgião Oncológico', true, '2025-05-14 00:45:57.264', (SELECT "Id" FROM public.professions WHERE name = 'Médico' LIMIT 1))

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250513172826_SeedSurgicalSpecialties', '8.0.15');

COMMIT;

