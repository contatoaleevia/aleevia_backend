START TRANSACTION;

ALTER TABLE public.ia_chat DROP CONSTRAINT "FK_ia_chat_user_SourceId";

DROP INDEX public."IX_ia_chat_SourceId";

ALTER TABLE public.ia_chat RENAME COLUMN "SourceId" TO source_id;

ALTER TABLE public.ia_chat ALTER COLUMN source_id DROP NOT NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250513231752_MakeSourceIdNullableInIaChat', '8.0.15');

COMMIT;

START TRANSACTION;

ALTER TABLE public.faq_page ADD source_type integer NOT NULL DEFAULT 0;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250514004126_AddSourceTypeEnumToFaqPage', '8.0.15');

COMMIT;

START TRANSACTION;

ALTER TABLE public.faq ADD is_active boolean NOT NULL DEFAULT TRUE;

ALTER TABLE public.faq ADD link character varying(500);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250515160224_AddIsActiveToFaq', '8.0.15');

COMMIT;

START TRANSACTION;

CREATE TABLE public.healthcare (
    id uuid NOT NULL,
    office_id uuid NOT NULL,
    name character varying(100) NOT NULL,
    ans_number character varying(20),
    registry character varying(20),
    is_active boolean NOT NULL DEFAULT TRUE,
    created_at timestamp with time zone NOT NULL,
    updated_at timestamp with time zone,
    CONSTRAINT "PK_healthcare" PRIMARY KEY (id),
    CONSTRAINT "FK_healthcare_office_office_id" FOREIGN KEY (office_id) REFERENCES public.office (id)
);

CREATE INDEX "IX_healthcare_office_id" ON public.healthcare (office_id);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250515173954_AddHealthCareTable', '8.0.15');

COMMIT;

START TRANSACTION;

CREATE TABLE public.rating_chat (
    "Id" uuid NOT NULL,
    "ChatId" uuid NOT NULL,
    general integer NOT NULL,
    experience integer NOT NULL,
    utility integer NOT NULL,
    problem_solved integer NOT NULL,
    comment text,
    created_at timestamp with time zone NOT NULL,
    CONSTRAINT "PK_rating_chat" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_rating_chat_ia_chat_ChatId" FOREIGN KEY ("ChatId") REFERENCES public.ia_chat (id)
);

CREATE INDEX "IX_rating_chat_ChatId" ON public.rating_chat ("ChatId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250515235046_AddAiChatRating', '8.0.15');

COMMIT;

START TRANSACTION;

CREATE TABLE public.professional_address (
    "Id" uuid NOT NULL,
    "ProfessionalId" uuid NOT NULL,
    "AddressId" uuid NOT NULL,
    CONSTRAINT "PK_professional_address" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_professional_address_address_AddressId" FOREIGN KEY ("AddressId") REFERENCES public.address (id),
    CONSTRAINT "FK_professional_address_professional_ProfessionalId" FOREIGN KEY ("ProfessionalId") REFERENCES public.professional (id)
);

CREATE INDEX "IX_professional_address_AddressId" ON public.professional_address ("AddressId");

CREATE INDEX "IX_professional_address_ProfessionalId" ON public.professional_address ("ProfessionalId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250518124343_AddProfessionalAddress', '8.0.15');

COMMIT;

START TRANSACTION;

ALTER TABLE public.professional_address DROP CONSTRAINT "FK_professional_address_address_AddressId";

ALTER TABLE public.professional_address DROP CONSTRAINT "FK_professional_address_professional_ProfessionalId";

ALTER TABLE public.professional_address RENAME COLUMN "Id" TO id;

ALTER TABLE public.professional_address RENAME COLUMN "ProfessionalId" TO professional_id;

ALTER TABLE public.professional_address RENAME COLUMN "AddressId" TO address_id;

ALTER INDEX public."IX_professional_address_ProfessionalId" RENAME TO "IX_professional_address_professional_id";

ALTER INDEX public."IX_professional_address_AddressId" RENAME TO "IX_professional_address_address_id";

ALTER TABLE public.professional_address ADD CONSTRAINT "FK_professional_address_address_address_id" FOREIGN KEY (address_id) REFERENCES public.address (id);

ALTER TABLE public.professional_address ADD CONSTRAINT "FK_professional_address_professional_professional_id" FOREIGN KEY (professional_id) REFERENCES public.professional (id);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250518142431_UpdateProfessionalAddress', '8.0.15');

COMMIT;

START TRANSACTION;

ALTER TABLE public.ia_chat ADD hash_source uuid;

ALTER TABLE public.ia_chat ADD hash_source_type integer;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250520012355_AddFieldsToIaChat', '8.0.15');

COMMIT;

START TRANSACTION;

ALTER TABLE public.faq_page ALTER COLUMN custom_url TYPE character varying(500);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250521142423_UpdateFaqPageCustomUrlLength', '8.0.15');

COMMIT;

START TRANSACTION;

ALTER TABLE public.office_attendance ADD duration integer NOT NULL DEFAULT 0;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250521145529_AddDurationToOfficeAttendance', '8.0.15');

COMMIT;

