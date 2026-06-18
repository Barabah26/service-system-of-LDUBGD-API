using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using service_system_of_LDUBGD_API.Application.DTOs.Auth;
using service_system_of_LDUBGD_API.Common.Constants;
using service_system_of_LDUBGD_API.Common.Results;
using service_system_of_LDUBGD_API.Domain;

namespace service_system_of_LDUBGD_API.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AuthController(UserManager<ApplicationUser> userManager) : BaseApiController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
    {
        var user = new ApplicationUser
        {
            FirstName = registerUserDto.FirstName,
            LastName = registerUserDto.LastName,
            Email = registerUserDto.Email,
            Login = registerUserDto.Login,
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
            return MapErrorsToResponse(errors);
        }

        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDto loginUserDto)
    {
        var user = await userManager.FindByEmailAsync(loginUserDto.Email);
        if (user == null)
        {
            return Unauthorized(new { message = "Invalid credentials" });
        }

        var isPasswordValid = await userManager.CheckPasswordAsync(user, loginUserDto.Password);
        if (!isPasswordValid)
        {
            return Unauthorized(new { message = "Invalid credentials" });
        }

        return Ok();
    }
}
