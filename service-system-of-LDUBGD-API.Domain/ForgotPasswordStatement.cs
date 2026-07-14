using service_system_of_LDUBGD_API.Common.Enums;

namespace service_system_of_LDUBGD_API.Domain;

public class ForgotPasswordStatement
{
    public int Id { get; set; }

    public required ForgotPasswordStatementType TypeOfForgotPassword { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }
    public required StatementStatus Status { get; set; }

    public required string UserId { get; set; }

    public ApplicationUser User { get; set; } = null!;

}
