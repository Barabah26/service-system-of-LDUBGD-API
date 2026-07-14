using service_system_of_LDUBGD_API.Common.Enums;

namespace service_system_of_LDUBGD_API.Application.DTOs.ForgotPasswordStatement;

public class GetForgotPasswordStatementDto
{
    public int Id { get; set; }
    public ForgotPasswordStatementType TypeOfForgotPassword { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public StatementStatus Status { get; set; }
    public string UserId { get; set; }
}
