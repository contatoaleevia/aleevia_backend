using System;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Professional : BaseEntity
    {
        public int UserId { get; private set; }
        public bool Active { get; private set; }
        public ApprovalStatus Status { get; private set; }
        public string Email { get; private set; }
        public bool EmailVerified { get; private set; }
        public string Phone { get; private set; }
        public bool PhoneVerified { get; private set; }
        public string CNPJ { get; private set; }
        public string Password { get; private set; }
        public string FaqUrl { get; private set; }
        public string Website { get; private set; }
        public string Instagram { get; private set; }
        public string LinkedIn { get; private set; }
        public string Doctoralia { get; private set; }
        public string Biography { get; private set; }
        public string PictureUrl { get; private set; }
        public string GoogleToken { get; private set; }
        public string GoogleRefreshToken { get; private set; }
        public bool PreRegister { get; private set; }

        public User User { get; private set; }

        protected Professional() { } // For EF Core

        public Professional(int userId, string email, string password)
        {
            UserId = userId;
            Email = email;
            Password = password;
            Active = true;
            Status = ApprovalStatus.PENDING;
            EmailVerified = false;
            PhoneVerified = false;
            PreRegister = false;
        }

        public void UpdateStatus(ApprovalStatus status)
        {
            Status = status;
            SetUpdatedAt();
        }

        public void UpdateContactInfo(string email, string phone, string cnpj)
        {
            Email = email;
            Phone = phone;
            CNPJ = cnpj;
            SetUpdatedAt();
        }

        public void UpdateSocialMedia(string website, string instagram, string linkedin, string doctoralia)
        {
            Website = website;
            Instagram = instagram;
            LinkedIn = linkedin;
            Doctoralia = doctoralia;
            SetUpdatedAt();
        }

        public void UpdateProfile(string biography, string pictureUrl, string faqUrl)
        {
            Biography = biography;
            PictureUrl = pictureUrl;
            FaqUrl = faqUrl;
            SetUpdatedAt();
        }

        public void SetGoogleTokens(string token, string refreshToken)
        {
            GoogleToken = token;
            GoogleRefreshToken = refreshToken;
            SetUpdatedAt();
        }

        public void VerifyEmail()
        {
            EmailVerified = true;
            SetUpdatedAt();
        }

        public void VerifyPhone()
        {
            PhoneVerified = true;
            SetUpdatedAt();
        }

        public void SetActive(bool active)
        {
            Active = active;
            SetUpdatedAt();
        }

        public void SetPreRegister(bool preRegister)
        {
            PreRegister = preRegister;
            SetUpdatedAt();
        }
    }
} 