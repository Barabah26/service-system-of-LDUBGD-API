using System.ComponentModel.DataAnnotations;

namespace service_system_of_LDUBGD_API.Application.DTOs.Auth;

public class LoginUserDto
{
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}
