
using service_system_of_LDUBGD_API.Common.Enums;

namespace service_system_of_LDUBGD_API.Application.DTOs.Statement;

public record GetStatementDto
(
    int StatementId,
    string FullName, 
    DateTime DateOfBirth, 
    string Group, 
    string PhoneNumber, 
    string Faculty, 
    StatementType TypeOfStatement, 
    string UserId
);

