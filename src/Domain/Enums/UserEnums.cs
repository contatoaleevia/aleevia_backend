namespace Domain.Enums
{
    public enum Gender
    {
        MAN_CIS,
        WOMAN_CIS,
        WOMAN_TRANS,
        MAN_TRANS,
        NON_BINARY,
        PREFER_NOT_TO_SAY,
        OTHER
    }

    public enum BiologicalSex
    {
        MALE,
        FEMALE
    }

    public enum BloodType
    {
        A_POS,
        A_NEG,
        B_POS,
        B_NEG,
        AB_POS,
        AB_NEG,
        O_POS,
        O_NEG
    }

    public enum ApprovalStatus
    {
        PENDING,
        APPROVED,
        DECLINED
    }

    public enum AppointmentType
    {
        TELECONSULTATION,
        PRESENTIAL
    }

    public enum AppointmentStatus
    {
        PENDING,
        CONFIRMED,
        CANCELED,
        COMPLETED
    }

    public enum DocumentType
    {
        CRM,
        CRO,
        COREN,
        CRP,
        CRF,
        CREFITO,
        CRBM,
        CRN,
        CREFONO,
        CRTR,
        CREF
    }

    public enum AddressSource
    {
        PATIENT,
        PROFESSIONAL
    }
} 