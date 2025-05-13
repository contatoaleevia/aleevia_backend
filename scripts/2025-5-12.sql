START TRANSACTION;

ALTER TABLE public.office ADD individual boolean NOT NULL DEFAULT FALSE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250512143458_AddIndividualToOffice', '8.0.15');

COMMIT;

START TRANSACTION;

ALTER TABLE public.professional_documents DROP CONSTRAINT "FK_professional_documents_professional_ProfessionalId1";

ALTER TABLE public.professional_specialty_details DROP CONSTRAINT "FK_professional_specialty_details_professional_ProfessionalId1";

DROP INDEX public."IX_professional_specialty_details_ProfessionalId1";

DROP INDEX public."IX_professional_documents_ProfessionalId1";

ALTER TABLE public.professional_specialty_details DROP COLUMN "ProfessionalId1";

ALTER TABLE public.professional_documents DROP COLUMN "ProfessionalId1";

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250512162912_FixProfessionalRelationships', '8.0.15');

COMMIT;

