using Application.DTOs.Users.CreateAdminUserDTOs;
using Application.DTOs.Patients.CreatePatientDTOs;
using Application.DTOs.Users.IsRegisteredDTOs;
using Application.DTOs.Users.RetrieveUserDTOs;
using Domain.Entities.Identities;

namespace Application.Services.Users
{
    public interface IUserService
    {
        Task<CreateManagerUserResponse> CreateManagerUserAsync(CreateManagerUserRequest request);
        Task<CreatePatientUserResponse> CreatePatientUserAsync(CreatePatientUserRequest request);
        Task<IsRegisteredResponse> IsRegisteredAsync(string document);
        Task<Tuple<Manager, string>> CreateProfessionalUserAsync(CreateProfessionalUserRequest request);
    }
}