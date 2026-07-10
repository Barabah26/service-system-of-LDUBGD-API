namespace service_system_of_LDUBGD_API.Application.DTOs.Auth;

public class RegisteredUserDto
{
    public string Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Faculty { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
    public string Degree { get; set; } = string.Empty;
    public string Group { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateOnly? DateBirth { get; set; }
    public string Role { get; set; }
}
