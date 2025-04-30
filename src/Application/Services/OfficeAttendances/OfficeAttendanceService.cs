using Application.DTOs.OfficeAttendance.CreateOfficeAttendanceDTOs;
using Application.DTOs.OfficeAttendance.DeactivateOfficeAttendanceDTOs;
using Application.DTOs.OfficeAttendance.GetOfficeAttendanceDTOs;
using Domain.Contracts.Repositories;
using Domain.Entities.OfficeAttendances;
using Domain.Exceptions;
namespace Application.Services.OfficeAttendances;

public class OfficeAttendanceService(
    IOfficeAttendanceRepository officeAttendanceRepository,
    IServiceTypeRepository serviceTypeRepository
) : IOfficeAttendanceService
{
    public async Task<CreateOfficeAttendanceResponseDto> CreateAsync(CreateOfficeAttendanceRequestDto requestDto)
    {
        var serviceType = await serviceTypeRepository.GetByIdAsync(requestDto.ServiceTypeId);
        if (serviceType is null || !serviceType.Active)
            throw new ServiceTypeNotFoundException(requestDto.ServiceTypeId);

        var serviceTypeExists = await officeAttendanceRepository.ExistsByOfficeIdAndServiceTypeIdAsync(
            requestDto.OfficeId, requestDto.ServiceTypeId);
        if (serviceTypeExists)
            throw new OfficeServiceAlreadyChainedException(requestDto.OfficeId, requestDto.ServiceTypeId);

        var officeAttendance = new OfficeAttendance(
            officeId: requestDto.OfficeId,
            serviceTypeId: requestDto.ServiceTypeId,
            title: requestDto.Title,
            price: requestDto.Price,
            description: requestDto.Description
        );

        await officeAttendanceRepository.CreateAsync(officeAttendance);

        return new CreateOfficeAttendanceResponseDto
        {
            Id = officeAttendance.Id,
            OfficeId = officeAttendance.OfficeId,
            ServiceTypeId = officeAttendance.ServiceTypeId,
            Title = officeAttendance.Title,
            Description = officeAttendance.Description,
            Price = officeAttendance.Price,
            Active = officeAttendance.Active,
            CreatedAt = officeAttendance.CreatedAt
        };
    }

    public async Task<List<GetOfficeAttendanceResponseDto>> GetAllByOfficeIdAsync(Guid officeId)
    {
        var officeAttendances = await officeAttendanceRepository.GetAllByOfficeIdAsync(officeId);
        
        return [.. officeAttendances.Select(oa => new GetOfficeAttendanceResponseDto
        {
            Id = oa.Id,
            OfficeId = oa.OfficeId,
            ServiceTypeId = oa.ServiceTypeId,
            Title = oa.Title,
            Description = oa.Description,
            Price = oa.Price,
            Active = oa.Active,
            CreatedAt = oa.CreatedAt,
            UpdatedAt = oa.UpdatedAt,
            ServiceTypeName = oa.ServiceType.Name,
            ServiceTypeDescription = oa.ServiceType.Description
        })];
    }

    public async Task<DeactivateOfficeAttendanceResponseDto> DeactivateAsync(DeactivateOfficeAttendanceRequestDto requestDto)
    {
        var officeAttendance = await officeAttendanceRepository.GetByIdAsync(requestDto.Id) ?? throw new OfficeAttendanceNotFoundException(requestDto.Id);
        officeAttendance.Deactivate();
        await officeAttendanceRepository.UpdateAsync(officeAttendance);

        return new DeactivateOfficeAttendanceResponseDto
        {
            Id = officeAttendance.Id,
            Active = officeAttendance.Active,
            UpdatedAt = officeAttendance.UpdatedAt
        };
    }
} 