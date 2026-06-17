
using service_system_of_LDUBGD_API.Common.Enums;

namespace service_system_of_LDUBGD_API.Application.DTOs.Statement;

public class UpdateStatementDto
{
    public required int StatementId { get; init; }
    public StatementStatus Status { get; init; }
}

