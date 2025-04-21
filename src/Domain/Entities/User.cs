using System;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string CPF { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName { get; private set; }
        public string PreferredName { get; private set; }
        public Gender? Gender { get; private set; }
        public BiologicalSex? BiologicalSex { get; private set; }
        public BloodType? BloodType { get; private set; }
        public DateTime? BirthDate { get; private set; }

        protected User() { } // For EF Core

        public User(string cpf, string firstName, string lastName)
        {
            CPF = cpf;
            FirstName = firstName;
            LastName = lastName;
            UpdateFullName();
        }

        private void UpdateFullName()
        {
            FullName = $"{FirstName} {LastName}".Trim();
        }

        public void UpdateNames(string firstName, string lastName, string preferredName = null)
        {
            FirstName = firstName;
            LastName = lastName;
            PreferredName = preferredName;
            UpdateFullName();
            SetUpdatedAt();
        }

        public void UpdatePersonalInfo(Gender? gender, BiologicalSex? biologicalSex, BloodType? bloodType, DateTime? birthDate)
        {
            Gender = gender;
            BiologicalSex = biologicalSex;
            BloodType = bloodType;
            BirthDate = birthDate;
            SetUpdatedAt();
        }
    }
} 