using Microsoft.AspNetCore.Identity;

namespace service_system_of_LDUBGD_API.Domain;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Faculty { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
    public string Degree { get; set; } = string.Empty;
    public string Group { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime? DateBirth { get; set; }
    public List<Statement> Statements { get; set; } = new();
    public string FullName => $"{LastName}, {FirstName}";
}