
using service_system_of_LDUBGD_API.Common.Enums;

namespace service_system_of_LDUBGD_API.Application.DTOs.Statement;

public class GetStatementDto
{
    public int StatementId { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Group { get; set; }
    public string PhoneNumber { get; set; }
    public string Faculty { get; set; }
    public StatementType TypeOfStatement { get; set; }
    public string UserId { get; set; }
}

