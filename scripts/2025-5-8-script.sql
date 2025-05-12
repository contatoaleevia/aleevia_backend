START TRANSACTION;

ALTER TABLE public.professional ADD email character varying(100);

ALTER TABLE public.professional ADD name character varying(100);

ALTER TABLE public.professional ADD preferred_name character varying(100);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250508235543_UpdateProfessionalAddNameEmail', '8.0.15');

COMMIT;

