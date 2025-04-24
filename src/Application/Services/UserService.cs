using Application.DTOs.Users.CreateUserDTOs;
using Application.DTOs.Users.GetUserById;
using CrossCutting.Identities;
using Domain.Entities.Identities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;

public class UserService(
    UserManager<User> userManager,
    IIdentityNotificationHandler identityNotificationHandler
) : IUserService
{
    public async Task<GetUserByIdResponse> GetByGuidAsync(Guid guid)
    {
        var user = await userManager.FindByIdAsync(guid.ToString());
        if(user is null) throw new UserNotFoundException(guid);
        //TODO: Preencher response com os dados do usuário
        return new GetUserByIdResponse();
    }

    public async Task<CreateUserResponseDto> CreateUserAsync(CreateUserRequestDto requestDto)
    {
        var user = new User(
            userName: requestDto.UserName,
            email: requestDto.Email,
            phoneNumber: requestDto.PhoneNumber,
            firstName: requestDto.FirstName,
            lastName: requestDto.LastName,
            preferredName: requestDto.PreferredName,
            gender: requestDto.Gender,
            document: requestDto.Document,
            userType: requestDto.UserType);
            
        var response = await userManager.CreateAsync(user, requestDto.Password);
        if (response.Succeeded) 
            return new CreateUserResponseDto(user.Id, user.UserName!, user.Email!);
        
        identityNotificationHandler.AddNotifications(response.Errors);
        return new CreateUserResponseDto();
    }

    // public async Task UpdateAsync(CreateUserRequestDto requestDto)
    // {
    //     var user = new User(userName: requestDto.Email, requestDto.Email, requestDto.PhoneNumber, requestDto.Gender, requestDto.FirstName,
    //         requestDto.LastName, requestDto.PreferredName, requestDto.Active, requestDto.Document);
    //     await userRepository.UpdateAsync(user);
    // }
    //
    // public async Task DeleteAsync(CreateUserRequestDto requestDto)
    // {
    //     var user = new User(userName: requestDto.Email, requestDto.Email, requestDto.PhoneNumber, requestDto.Gender, requestDto.FirstName,
    //         requestDto.LastName, requestDto.PreferredName, requestDto.Active, requestDto.Document);
    //     await userRepository.DeleteAsync(user);
    // }
}