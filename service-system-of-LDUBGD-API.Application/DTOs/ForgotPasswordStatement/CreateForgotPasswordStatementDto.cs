using service_system_of_LDUBGD_API.Common.Enums;

namespace service_system_of_LDUBGD_API.Application.DTOs.ForgotPasswordStatement;

public class CreateForgotPasswordStatementDto
{
    public required string FullName { get; init; }
    public required string Group { get; init; }
    public required string Email { get; init; }
    public required ForgotPasswordStatementType TypeOfStatement { get; init; }
}
