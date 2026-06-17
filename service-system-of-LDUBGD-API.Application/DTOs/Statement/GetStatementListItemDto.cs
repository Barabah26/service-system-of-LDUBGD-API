
using service_system_of_LDUBGD_API.Common.Enums;

namespace service_system_of_LDUBGD_API.Application.DTOs.Statement;

public record GetStatementListItemDto(
    int StatementId,
    string FullName,
    StatementType TypeOfStatement,
    string Group,
    StatementStatus Status
);

