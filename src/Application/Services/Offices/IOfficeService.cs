﻿using Application.DTOs.Offices.BindOfficeAddressDTOs;
using Application.DTOs.Offices.BindOfficeProfessionalDTOs;
using Application.DTOs.Offices.BindOfficeSpecialtyDTOs;
using Application.DTOs.Offices.CreateOfficeDTOs;
using Application.DTOs.Offices.GetOfficeDTOs;
using Application.DTOs.Offices.UpdateOfficeDTOs;
using Application.DTOs.Professionals;

namespace Application.Services.Offices;

public interface IOfficeService
{
    Task<CreateOfficeResponse> CreateOffice(CreateOfficeRequest request, Guid userId);
    Task<UpdateOfficeResponse> UpdateOffice(UpdateOfficeRequest request, Guid userId);
    Task<BindOfficeAddressResponse> BindOfficeAddress(BindOfficeAddressRequest request, Guid userId);
    Task DeleteOfficeAddress(Guid officeAddressId);
    Task<BindOfficeProfessionalResponse> BindOfficeProfessional(BindOfficeProfessionalRequest request);
    Task DeactivateOfficeProfessional(DeactivateOfficeProfessionalRequest request);
    Task<BindOfficeSpecialtyResponse> BindOfficeSpecialty(BindOfficeSpecialtyRequest request);
    Task DeactivateOfficeSpecialty(DeactivateOfficeSpecialtyRequest request);
    Task<OfficeResponse> GetOfficeById(Guid id);
    Task<List<OfficeSimplifiedResponse>> GetOfficesByUserId(Guid userId);
    Task<GetOfficeProfessionalsResponse> GetOfficeProfessionals(Guid officeId);
}