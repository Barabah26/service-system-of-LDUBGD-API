using Microsoft.AspNetCore.Identity;
using service_system_of_LDUBGD_API.Application.Contracts;
using service_system_of_LDUBGD_API.Application.DTOs.Auth;
using service_system_of_LDUBGD_API.Common.Constants;
using service_system_of_LDUBGD_API.Common.Results;
using service_system_of_LDUBGD_API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_system_of_LDUBGD_API.Application.Services;

public class UsersService(UserManager<ApplicationUser> userManager) : IUsersService
{
    public async Task<Result<RegisteredUserDto>> RegisterAsync(RegisterUserDto registerUserDto)
    {
        var user = new ApplicationUser
        {
            FirstName = registerUserDto.FirstName,
            LastName = registerUserDto.LastName,
            Email = registerUserDto.Email,
            Faculty = registerUserDto.Faculty,
            PhoneNumber = registerUserDto.PhoneNumber,
            Specialty = registerUserDto.Specialty,
            Degree = registerUserDto.Degree,
            Group = registerUserDto.Group,
            DateBirth = registerUserDto.DateBirth
        };

        var result = await userManager.CreateAsync(user, registerUserDto.Password);

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => new Error(ErrorCodes.BadRequest, e.Description)).ToArray();
            return Result<RegisteredUserDto>.BadRequest(errors);
        }

        var registeredUser = new RegisteredUserDto
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Faculty = user.Faculty,
            PhoneNumber = user.PhoneNumber,
            Specialty = user.Specialty,
            Degree = user.Degree,
            Group = user.Group,
            DateBirth = user.DateBirth,
            Id = user.Id
        };

        return Result<RegisteredUserDto>.Success(registeredUser);
    }

    public async Task<Result<string>> LoginAsync(LoginUserDto loginUserDto)
    {
        var user = await userManager.FindByEmailAsync(loginUserDto.Email);
        if (user == null)
        {
            return Result<string>.Failure(new Error(ErrorCodes.BadRequest, "Invalid credentials"));
        }

        var isPasswordValid = await userManager.CheckPasswordAsync(user, loginUserDto.Password);
        if (!isPasswordValid)
        {
            return Result<string>.Failure(new Error(ErrorCodes.BadRequest, "Invalid credentials"));
        }

        return Result<string>.Success("Login successful.");
    }
}
