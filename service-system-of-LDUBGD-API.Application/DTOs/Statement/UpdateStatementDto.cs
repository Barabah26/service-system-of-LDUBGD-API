
using service_system_of_LDUBGD_API.Common.Enums;

namespace service_system_of_LDUBGD_API.Application.DTOs.Statement;

public class UpdateStatementDto
{
    public required int StatementId { get; init; }

    public string? FullName { get; init; }
    public DateTime? DateOfBirth { get; init; }
    public string? Group { get; init; }
    public string? PhoneNumber { get; init; }
    public string? Faculty { get; init; }
    public string? Status { get; init; }
    public StatementType? TypeOfStatement { get; init; }
}

