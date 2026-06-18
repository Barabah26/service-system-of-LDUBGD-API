using service_system_of_LDUBGD_API.Application.DTOs.Auth;
using service_system_of_LDUBGD_API.Common.Results;

namespace service_system_of_LDUBGD_API.Application.Contracts
{
    public interface IUsersService
    {
        Task<Result<string>> LoginAsync(LoginUserDto loginUserDto);
        Task<Result<RegisteredUserDto>> RegisterAsync(RegisterUserDto registerUserDto);
    }
}