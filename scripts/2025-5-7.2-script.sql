START TRANSACTION;

INSERT INTO public.professions ("Id", name, active, created_at)
VALUES ('1b728f95-a8e2-4600-929a-c3bc3dd57108', 'Médico', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.084749Z');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('65f370f0-519d-4f61-a916-99ac9f8d68dc', 'Clínico Geral', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085347Z', '1b728f95-a8e2-4600-929a-c3bc3dd57108');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('f9f851f6-c774-4bd7-a529-e3f45312b70a', 'Medicina Preventiva', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085349Z', '65f370f0-519d-4f61-a916-99ac9f8d68dc');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('0f9cb129-2793-4412-9ea3-032878aa5dcb', 'Medicina Ambulatorial', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085349Z', '65f370f0-519d-4f61-a916-99ac9f8d68dc');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('73e245c4-c55a-45c0-895a-4405a389fba9', 'Médico da Família', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085351Z', '1b728f95-a8e2-4600-929a-c3bc3dd57108');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('76cb339b-7293-4748-aac2-7e6316bbf431', 'Saúde da Família', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085352Z', '73e245c4-c55a-45c0-895a-4405a389fba9');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('659d53e7-1df7-485c-81d7-ed8183c603d0', 'Atenção Primária', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085352Z', '73e245c4-c55a-45c0-895a-4405a389fba9');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('fe8af268-dda6-4a11-987b-272c2ab8fcdb', 'Pediatra', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085352Z', '1b728f95-a8e2-4600-929a-c3bc3dd57108');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('145d2767-9d13-4ca2-a2d4-75eba6bb2520', 'Neonatologia', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085353Z', 'fe8af268-dda6-4a11-987b-272c2ab8fcdb');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('b130cfea-7026-4a01-9ed9-9206f7b64271', 'Alergia Pediátrica', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085353Z', 'fe8af268-dda6-4a11-987b-272c2ab8fcdb');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('6eb4c81c-243d-46fa-9597-8de0b0ee2010', 'Endocrinopediatria', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085353Z', 'fe8af268-dda6-4a11-987b-272c2ab8fcdb');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('75fc315f-a8b8-49ab-97fb-5757c42c8aaa', 'Cardiologista', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085354Z', '1b728f95-a8e2-4600-929a-c3bc3dd57108');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('0b719d15-71d6-4a1c-b6ed-c5f06d2d932e', 'Eletrofisiologia', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085354Z', '75fc315f-a8b8-49ab-97fb-5757c42c8aaa');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('5d6af43a-2daf-412e-95fc-d1a29a6485dd', 'Hemodinâmica', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085354Z', '75fc315f-a8b8-49ab-97fb-5757c42c8aaa');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('3c3b92a4-79b7-45c0-9e4e-a9bbdd473434', 'Insuficiência Cardíaca', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085355Z', '75fc315f-a8b8-49ab-97fb-5757c42c8aaa');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('c2c58299-c487-4a99-a539-ef29a22b7e02', 'Dermatologista', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085355Z', '1b728f95-a8e2-4600-929a-c3bc3dd57108');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('5d5bd1fd-9656-4b8a-be33-a1bb9a758b43', 'Dermatologia Estética', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085355Z', 'c2c58299-c487-4a99-a539-ef29a22b7e02');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('440381b9-6d09-43b3-9f12-4a44605d3754', 'Dermatopatologia', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085355Z', 'c2c58299-c487-4a99-a539-ef29a22b7e02');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('739a4d20-1caf-4d02-9adf-36c15d643ce1', 'Cirurgia Dermatológica', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.08536Z', 'c2c58299-c487-4a99-a539-ef29a22b7e02');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('eb28287e-cadc-4a24-ac72-72c01b94070f', 'Endocrinologista', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085361Z', '1b728f95-a8e2-4600-929a-c3bc3dd57108');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('11f39976-e5cf-4e13-84d1-e69815a0bfe7', 'Endocrinopediatria', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085361Z', 'eb28287e-cadc-4a24-ac72-72c01b94070f');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('72dc5801-744e-4ca2-9aed-88905fb046f4', 'Diabetes', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085362Z', 'eb28287e-cadc-4a24-ac72-72c01b94070f');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('0f4b85d4-a31b-4437-9395-c2eac7963b82', 'Obesidade', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085362Z', 'eb28287e-cadc-4a24-ac72-72c01b94070f');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('e7e64b31-8fab-4d7c-9b57-3da721589461', 'Tireoide', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085362Z', 'eb28287e-cadc-4a24-ac72-72c01b94070f');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('6e53a788-d851-45ab-9401-6bf7b1ec160d', 'Neurologista', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085362Z', '1b728f95-a8e2-4600-929a-c3bc3dd57108');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('60d1d297-f858-4e30-be1e-b3a857d0eb55', 'Neurovascular', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085363Z', '6e53a788-d851-45ab-9401-6bf7b1ec160d');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('98c929aa-1357-4d0b-9b08-0048f8261cf7', 'Epilepsia', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085363Z', '6e53a788-d851-45ab-9401-6bf7b1ec160d');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('620711c7-0681-4726-bc00-e4be32b625fc', 'Neuroimunologia', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085363Z', '6e53a788-d851-45ab-9401-6bf7b1ec160d');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('abfc4dfd-2b6a-4eef-bf7c-0aa479009d21', 'Neurologia Pediátrica', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085363Z', '6e53a788-d851-45ab-9401-6bf7b1ec160d');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('67ed58d8-9500-45b5-9a4b-ad938bebed4a', 'Ortopedista', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085364Z', '1b728f95-a8e2-4600-929a-c3bc3dd57108');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('dba670df-4bf2-4aae-b460-03851e808a3f', 'Ortopedia Pediátrica', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085364Z', '67ed58d8-9500-45b5-9a4b-ad938bebed4a');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('2ec725b6-2b9e-4a19-914c-fbddd5a181ff', 'Cirurgia da Coluna', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085364Z', '67ed58d8-9500-45b5-9a4b-ad938bebed4a');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('e4f907d2-def1-4dc3-94db-32b6b0f43270', 'Medicina Esportiva', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085364Z', '67ed58d8-9500-45b5-9a4b-ad938bebed4a');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('b83827be-35bf-45e5-b846-630004a1c5a5', 'Ginecologista', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085365Z', '1b728f95-a8e2-4600-929a-c3bc3dd57108');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('60ace8f9-6275-4d4f-90c3-63c7770bf1b4', 'Obstetrícia', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085365Z', 'b83827be-35bf-45e5-b846-630004a1c5a5');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('7cc78563-98af-44a7-adb2-04cc9237ad67', 'Reprodução Humana', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085365Z', 'b83827be-35bf-45e5-b846-630004a1c5a5');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('9cd18c3b-7099-4926-9e5e-20b23d0b417f', 'Uroginecologia', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085368Z', 'b83827be-35bf-45e5-b846-630004a1c5a5');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('fef3d419-92a6-4b96-ab38-2aa051381eaf', 'Psiquiatra', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085369Z', '1b728f95-a8e2-4600-929a-c3bc3dd57108');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('12ba1ce5-7ebb-4a45-a298-9ed7f81fdcf9', 'Psiquiatria Infantil', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085369Z', 'fef3d419-92a6-4b96-ab38-2aa051381eaf');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('a6a524dc-0267-49ab-aad6-f05d35b60367', 'Psicogeriatria', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085369Z', 'fef3d419-92a6-4b96-ab38-2aa051381eaf');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('499291ec-f208-4833-82bb-5b6924949cd0', 'Dependência Química', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085369Z', 'fef3d419-92a6-4b96-ab38-2aa051381eaf');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('8d76e2af-3390-419c-8760-ed773dceeef0', 'Oftalmologista', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.08537Z', '1b728f95-a8e2-4600-929a-c3bc3dd57108');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('685c5cf9-3c5c-40f2-bb8d-289d2dde9398', 'Retina', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.08537Z', '8d76e2af-3390-419c-8760-ed773dceeef0');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('8c3f0a4a-7816-4a06-9e96-fe5978757083', 'Glaucoma', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.08537Z', '8d76e2af-3390-419c-8760-ed773dceeef0');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('68d91c5b-e2cb-4584-9b67-7fecc1af13be', 'Córnea', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.08537Z', '8d76e2af-3390-419c-8760-ed773dceeef0');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('07838159-0397-4412-807f-f4ba739ebcc4', 'Cirurgia Refrativa', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085371Z', '8d76e2af-3390-419c-8760-ed773dceeef0');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('4242ab7e-3a71-4cb6-9e98-47057245f254', 'Otorrinolaringologista', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085371Z', '1b728f95-a8e2-4600-929a-c3bc3dd57108');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('27a4e6c3-89af-43b7-bd0a-57c469308a35', 'Otologia', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085371Z', '4242ab7e-3a71-4cb6-9e98-47057245f254');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('545072a7-4df7-4af2-a3ab-305d73e3dd70', 'Rinologia', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085371Z', '4242ab7e-3a71-4cb6-9e98-47057245f254');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('352a5967-ab29-423b-afa3-7f8a1a2cc278', 'Otoneurologia', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085372Z', '4242ab7e-3a71-4cb6-9e98-47057245f254');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('9a27e477-8204-42d6-9f25-c085cc5665ce', 'Cirurgia de Cabeça e Pescoço', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085372Z', '4242ab7e-3a71-4cb6-9e98-47057245f254');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('76a7316d-41ab-485c-a00f-22725a18305c', 'Urologista', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085372Z', '1b728f95-a8e2-4600-929a-c3bc3dd57108');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('857c2e96-ba0c-4498-acee-557626d3eca7', 'Urologia Pediátrica', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085373Z', '76a7316d-41ab-485c-a00f-22725a18305c');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('1dcda8b8-7b7c-49c7-b5b7-008bafc780c7', 'Andrologia', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085373Z', '76a7316d-41ab-485c-a00f-22725a18305c');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('ba9b8781-165c-4ad6-bdf3-eac2e375b6cd', 'Oncologia Urológica', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085373Z', '76a7316d-41ab-485c-a00f-22725a18305c');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('f8881c8d-b94b-4ad8-811c-e85888881f5d', 'Nefrologista', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085376Z', '1b728f95-a8e2-4600-929a-c3bc3dd57108');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('c550d0ef-1ec1-4a62-8a08-83ea38eb06d3', 'Nefropediatria', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085376Z', 'f8881c8d-b94b-4ad8-811c-e85888881f5d');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('757113ce-c96f-4aa1-8ff8-3f5dbbbae000', 'Hemodiálise', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085376Z', 'f8881c8d-b94b-4ad8-811c-e85888881f5d');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('cae5b0ef-e458-452e-9b19-755f8a536105', 'Transplante Renal', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085376Z', 'f8881c8d-b94b-4ad8-811c-e85888881f5d');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('531c35c0-f7f5-467f-9ebd-8eea1b215619', 'Pneumologista', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085377Z', '1b728f95-a8e2-4600-929a-c3bc3dd57108');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('15de593e-0222-4c66-ae26-957221644f2b', 'Pneumologia Pediátrica', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085377Z', '531c35c0-f7f5-467f-9ebd-8eea1b215619');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('2a86c7ba-2e01-476f-909d-fa593fe4b01f', 'Sono', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085377Z', '531c35c0-f7f5-467f-9ebd-8eea1b215619');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('97a027ab-d909-4eaa-af0a-bab1f6b25e64', 'DPOC', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085378Z', '531c35c0-f7f5-467f-9ebd-8eea1b215619');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('4e6155a1-0ddd-4d0f-93b0-5d469dc4f6ba', 'Reumatologista', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085378Z', '1b728f95-a8e2-4600-929a-c3bc3dd57108');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('8f2fb439-b0bd-429c-b413-8180152af2c9', 'Reumatologia Pediátrica', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085378Z', '4e6155a1-0ddd-4d0f-93b0-5d469dc4f6ba');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('b04a1db5-1fb8-41b9-aa27-89ba694bac15', 'Doenças Autoimunes', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085378Z', '4e6155a1-0ddd-4d0f-93b0-5d469dc4f6ba');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('c3e65386-3217-43fd-9fa0-271c68f10fd0', 'Osteoporose', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085379Z', '4e6155a1-0ddd-4d0f-93b0-5d469dc4f6ba');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('f8fb5118-9102-4e6a-a023-75f3f4757dcd', 'Geriatra', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085379Z', '1b728f95-a8e2-4600-929a-c3bc3dd57108');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('af1210ef-66ee-42ae-a650-ee0818b458e2', 'Cuidados Paliativos', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085379Z', 'f8fb5118-9102-4e6a-a023-75f3f4757dcd');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('4cf6aa7d-5154-43f0-8f10-f9a156fa116b', 'Neurogeriatria', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085379Z', 'f8fb5118-9102-4e6a-a023-75f3f4757dcd');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('cc8b0583-3ae4-4479-95db-3bb549499ca8', 'Avaliação Multidimensional', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.08538Z', 'f8fb5118-9102-4e6a-a023-75f3f4757dcd');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('a252b9bb-3724-4acb-bf36-e0616a455625', 'Gastroenterologista', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085385Z', '1b728f95-a8e2-4600-929a-c3bc3dd57108');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('71cb9136-c689-4b94-9dfb-458c55521589', 'Hepatologia', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085386Z', 'a252b9bb-3724-4acb-bf36-e0616a455625');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('3151cae6-f234-4ee9-9e88-7a94dde9fa75', 'Endoscopia Digestiva', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085386Z', 'a252b9bb-3724-4acb-bf36-e0616a455625');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('2f35a77d-e4aa-4285-aee3-f16beefa023f', 'Gastroenterologia Pediátrica', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085386Z', 'a252b9bb-3724-4acb-bf36-e0616a455625');

INSERT INTO public.professions ("Id", name, active, created_at)
VALUES ('98f3c1b4-d3f7-4d6a-ae42-60bac2a9a836', 'Enfermeiro', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085387Z');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('adbcbbad-c622-448b-9a6d-8970c57ecec0', 'Enfermeiro', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085387Z', '98f3c1b4-d3f7-4d6a-ae42-60bac2a9a836');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('c4938906-389f-4b81-9961-ab222b91ee93', 'Obstétrica', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085388Z', 'adbcbbad-c622-448b-9a6d-8970c57ecec0');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('48aae62d-47ca-4fd8-8949-c52164bcf196', 'Pediátrica', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085388Z', 'adbcbbad-c622-448b-9a6d-8970c57ecec0');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('b7b09b08-7497-4e38-b9c7-41e4c1836aae', 'Geriátrica', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085388Z', 'adbcbbad-c622-448b-9a6d-8970c57ecec0');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('f01f30b1-2008-43d2-883c-f68771cd97ff', 'UTI', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085388Z', 'adbcbbad-c622-448b-9a6d-8970c57ecec0');

INSERT INTO public.professions ("Id", name, active, created_at)
VALUES ('f1cfd03b-c4b8-46e8-b31b-e2f7e409baf5', 'Técnico de Enfermagem', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085389Z');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('fbdd1352-a899-4398-b630-fc751dc71fe9', 'Técnico de Enfermagem', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085389Z', 'f1cfd03b-c4b8-46e8-b31b-e2f7e409baf5');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('fe91a14b-f377-407d-ad05-a667091163f8', 'Centro Cirúrgico', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085389Z', 'fbdd1352-a899-4398-b630-fc751dc71fe9');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('28131511-eb7b-49c7-a685-b1ec62da47b7', 'UTI', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.08539Z', 'fbdd1352-a899-4398-b630-fc751dc71fe9');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('a399fa3e-3807-4136-9f1d-935e7441755b', 'Domiciliar', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.08539Z', 'fbdd1352-a899-4398-b630-fc751dc71fe9');

INSERT INTO public.professions ("Id", name, active, created_at)
VALUES ('5cc755d6-1e25-4b23-9ab1-be61caeef05d', 'Nutricionista', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.08539Z');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('1f2eb979-1715-40f3-a742-88c9d56038dd', 'Nutricionista', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.08539Z', '5cc755d6-1e25-4b23-9ab1-be61caeef05d');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('24cace49-552e-41bc-b349-62ed21b98206', 'Esportiva', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085391Z', '1f2eb979-1715-40f3-a742-88c9d56038dd');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('d30f4e00-2e2b-41c5-8c13-ad6299968f7f', 'Clínica', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085391Z', '1f2eb979-1715-40f3-a742-88c9d56038dd');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('a65e2751-8a5d-4e74-af53-a954052d9a4c', 'Infantil', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085391Z', '1f2eb979-1715-40f3-a742-88c9d56038dd');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('f99a7bf1-30db-45ae-bbac-ffd434216867', 'Funcional', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085395Z', '1f2eb979-1715-40f3-a742-88c9d56038dd');

INSERT INTO public.professions ("Id", name, active, created_at)
VALUES ('85162f87-5c84-4c44-a758-48b6f8a0e5a0', 'Psicólogo', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085395Z');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('8816d8f1-101a-46c9-b06d-63cb736ce7c0', 'Psicólogo', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085396Z', '85162f87-5c84-4c44-a758-48b6f8a0e5a0');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('70afbcc8-35af-4f9f-b5f6-cefea3c9719f', 'Clínica', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085396Z', '8816d8f1-101a-46c9-b06d-63cb736ce7c0');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('cade353f-021f-4fbb-932f-9aa629ef9d65', 'Organizacional', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085396Z', '8816d8f1-101a-46c9-b06d-63cb736ce7c0');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('fe5b34fa-34c8-4d47-9c70-8eb8b2c246a4', 'Neuropsicologia', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085396Z', '8816d8f1-101a-46c9-b06d-63cb736ce7c0');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('9358f4a3-fd94-4b37-8359-037485c9e2fd', 'Psicopedagogia', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085397Z', '8816d8f1-101a-46c9-b06d-63cb736ce7c0');

INSERT INTO public.professions ("Id", name, active, created_at)
VALUES ('9dfbcd76-8c31-40cf-a39a-31d1105c1396', 'Fisioterapeuta', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085397Z');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('2834e595-2a55-4ef8-943a-411c2345edfa', 'Fisioterapeuta', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085397Z', '9dfbcd76-8c31-40cf-a39a-31d1105c1396');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('814e986a-5e18-44f5-9295-f5e56f152e8f', 'Respiratória', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085398Z', '2834e595-2a55-4ef8-943a-411c2345edfa');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('a88d4834-44b7-4bad-91f3-8be69fbc87c2', 'Ortopédica', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085398Z', '2834e595-2a55-4ef8-943a-411c2345edfa');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('d14972a9-7eb8-4294-9ba8-5bb2b53afdc4', 'Neurológica', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085398Z', '2834e595-2a55-4ef8-943a-411c2345edfa');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('6d86a235-54c5-410a-be09-4cd4b83a8243', 'Pélvica', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085398Z', '2834e595-2a55-4ef8-943a-411c2345edfa');

INSERT INTO public.professions ("Id", name, active, created_at)
VALUES ('adfc52ce-6bc7-4212-b226-60cf4eaa9535', 'Terapeuta Ocupacional', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085399Z');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('77a50c6d-1b41-4209-b984-ba5e360a7f02', 'Terapeuta Ocupacional', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085399Z', 'adfc52ce-6bc7-4212-b226-60cf4eaa9535');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('850bcbbc-86ba-4cad-bd0c-59216b6d94a4', 'Saúde Mental', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085399Z', '77a50c6d-1b41-4209-b984-ba5e360a7f02');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('f0deaab1-a79c-40f5-b626-394589a7595f', 'Reabilitação Física', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085399Z', '77a50c6d-1b41-4209-b984-ba5e360a7f02');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('cc017b3f-daaf-4c8b-8474-7bbfebbc7ac5', 'Pediatria', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.0854Z', '77a50c6d-1b41-4209-b984-ba5e360a7f02');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('ac9c3034-d807-4626-ac96-cc384277d1f7', 'Gerontologia', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.0854Z', '77a50c6d-1b41-4209-b984-ba5e360a7f02');

INSERT INTO public.professions ("Id", name, active, created_at)
VALUES ('f02e7e59-ac9c-4873-a792-af0733d8b6b4', 'Fonoaudiólogo', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.0854Z');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('c9f20d35-a365-4cd6-948e-d70ecf61587f', 'Fonoaudiólogo', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085403Z', 'f02e7e59-ac9c-4873-a792-af0733d8b6b4');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('b9b2fd1a-4079-4808-a92f-2f53fb22b7e6', 'Linguagem', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085404Z', 'c9f20d35-a365-4cd6-948e-d70ecf61587f');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('cf4bd203-1f37-46de-a687-50923171b17f', 'Motricidade Orofacial', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085404Z', 'c9f20d35-a365-4cd6-948e-d70ecf61587f');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('0867f99f-7bd7-4d39-8a1f-27ec25a0289d', 'Voz', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085404Z', 'c9f20d35-a365-4cd6-948e-d70ecf61587f');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('5065c61e-d332-4cdf-987b-7efa81f1b1b6', 'Audiologia', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085404Z', 'c9f20d35-a365-4cd6-948e-d70ecf61587f');

INSERT INTO public.professions ("Id", name, active, created_at)
VALUES ('e742faf1-c2bd-4bc1-aa29-80b7308546b9', 'Biomédico', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085405Z');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('40c38e39-4dfe-4ca6-8f2a-48804ce2d63c', 'Biomédico', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085405Z', 'e742faf1-c2bd-4bc1-aa29-80b7308546b9');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('bf7f4237-95c7-4d2b-a694-82ea7353325d', 'Estética', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085405Z', '40c38e39-4dfe-4ca6-8f2a-48804ce2d63c');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('d37c75ca-4a09-44f4-a29c-c7306229016c', 'Análises Clínicas', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085405Z', '40c38e39-4dfe-4ca6-8f2a-48804ce2d63c');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('f091efe4-49c7-4fe1-96cc-99dfc2c13e92', 'Imagenologia', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085406Z', '40c38e39-4dfe-4ca6-8f2a-48804ce2d63c');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('d42af47f-acad-45aa-bbb5-139fefa4ae9a', 'Genética', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085406Z', '40c38e39-4dfe-4ca6-8f2a-48804ce2d63c');

INSERT INTO public.professions ("Id", name, active, created_at)
VALUES ('3c637ef9-3b45-45d3-8c7b-82d6dd20d8f7', 'Dentista', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085406Z');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('b36f2eda-727c-442c-a9a8-0fed411eba04', 'Dentista', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085406Z', '3c637ef9-3b45-45d3-8c7b-82d6dd20d8f7');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('2290e196-59f3-4099-9070-ce554ca19246', 'Ortodontia', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085407Z', 'b36f2eda-727c-442c-a9a8-0fed411eba04');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('4ac5c6d7-a148-451c-a101-ebbbd6c5e70e', 'Endodontia', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085407Z', 'b36f2eda-727c-442c-a9a8-0fed411eba04');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('14b122d3-53f5-4cc6-b5c1-ea7dec764b07', 'Implantodontia', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085407Z', 'b36f2eda-727c-442c-a9a8-0fed411eba04');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('c897b32e-900a-4b64-8f2f-095737cc7856', 'Odontopediatria', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085407Z', 'b36f2eda-727c-442c-a9a8-0fed411eba04');

INSERT INTO public.professions ("Id", name, active, created_at)
VALUES ('70bb579d-7c9e-40d4-bb96-c714fca1fe9a', 'Acupunturista', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085408Z');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('c8547375-1817-4197-85ec-b8d27d4d9c21', 'Acupunturista', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085411Z', '70bb579d-7c9e-40d4-bb96-c714fca1fe9a');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('6ee91d6b-54aa-4ddb-a898-b32876da95b8', 'Dor Crônica', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085411Z', 'c8547375-1817-4197-85ec-b8d27d4d9c21');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('8b541bb3-f3b3-42b5-8313-9557753f72fa', 'Estética', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085411Z', 'c8547375-1817-4197-85ec-b8d27d4d9c21');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('826bdd2f-bcb9-438b-b037-e1c957bf9d7f', 'Ansiedade', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085412Z', 'c8547375-1817-4197-85ec-b8d27d4d9c21');

INSERT INTO public.professions ("Id", name, active, created_at)
VALUES ('be3b77d5-db6a-4de1-9989-053e4d62d788', 'Quiropraxista', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085412Z');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('185a3ae0-bfda-4576-864a-1ae8d5003b51', 'Quiropraxista', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085412Z', 'be3b77d5-db6a-4de1-9989-053e4d62d788');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('c03f4136-c026-4328-b00b-1a048af7f7ad', 'Coluna Vertebral', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085412Z', '185a3ae0-bfda-4576-864a-1ae8d5003b51');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('20f36d7e-a6a4-4165-81d0-93978356369c', 'Desportiva', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085413Z', '185a3ae0-bfda-4576-864a-1ae8d5003b51');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('b132cb89-bba6-4303-82d3-71e9bf7ecfea', 'Reabilitação Funcional', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085413Z', '185a3ae0-bfda-4576-864a-1ae8d5003b51');

INSERT INTO public.professions ("Id", name, active, created_at)
VALUES ('9fc46d31-9f43-4a77-9d98-6fbcb05733c6', 'Outros', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085413Z');

INSERT INTO public.specialties ("Id", name, active, created_at, profession_id)
VALUES ('a1ffdb9e-47da-4f5e-b080-a663379452f4', 'Outros', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085413Z', '9fc46d31-9f43-4a77-9d98-6fbcb05733c6');

INSERT INTO public.sub_specialties ("Id", name, active, created_at, specialty_id)
VALUES ('c3ff920e-d445-4bca-9bc8-5c9895120a26', 'Outros', TRUE, TIMESTAMPTZ '2025-05-07T23:18:35.085414Z', 'a1ffdb9e-47da-4f5e-b080-a663379452f4');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250507231555_SeedProfessionsTable', '8.0.15');

COMMIT;

