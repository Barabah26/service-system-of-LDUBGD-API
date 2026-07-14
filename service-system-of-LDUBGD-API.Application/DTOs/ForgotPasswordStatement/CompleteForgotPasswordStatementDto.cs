
namespace service_system_of_LDUBGD_API.Application.DTOs.ForgotPasswordStatement;

public class CompleteForgotPasswordStatementDto
{
    public int StatementId { get; init; }

    public string Login { get; init; } = null!;

    public string Password { get; init; } = null!;
}
