
using service_system_of_LDUBGD_API.Common.Enums;

namespace service_system_of_LDUBGD_API.Application.DTOs.Statement;

public class CreateStatementDto
{
    public required string FullName { get; init; }
    public required DateOnly DateOfBirth { get; init; }
    public required string Group { get; init; }
    public required string PhoneNumber { get; init; }
    public required string Faculty { get; init; }
    //public required string UserId { get; init; }
    public required StatementType TypeOfStatement { get; init; }
}

