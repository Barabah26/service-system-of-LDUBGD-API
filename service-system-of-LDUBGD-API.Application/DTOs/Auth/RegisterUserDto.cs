using service_system_of_LDUBGD_API.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_system_of_LDUBGD_API.Application.DTOs.Auth;

public class RegisterUserDto
{
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    [Required]
    public string Faculty { get; set; } = string.Empty;
    [Required]
    public string Specialty { get; set; } = string.Empty;
    [Required]
    public string Degree { get; set; } = string.Empty;
    [Required]
    public string Group { get; set; } = string.Empty;
    [Required]
    public string PhoneNumber { get; set; } = string.Empty;
    [Required]
    public DateOnly? DateBirth { get; set; }
    public string Role { get; set; } = RoleNames.Student;
}
