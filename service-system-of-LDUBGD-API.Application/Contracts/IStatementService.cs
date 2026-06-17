using service_system_of_LDUBGD_API.Application.DTOs.Statement;
using service_system_of_LDUBGD_API.Common.Results;

namespace service_system_of_LDUBGD_API.Application.Contracts;

public interface IStatementService
{
    Task<Result<GetStatementDto>> CreateStatement(CreateStatementDto statementDto);
    Task<Result<IEnumerable<GetStatementListItemDto>>> GetStatements();
    Task<Result<IEnumerable<GetStatementListItemDto>>> FindByName(string fullName);
    Task<Result<IEnumerable<GetStatementListItemDto>>> FindByNameAndStatus(string fullName, string status);

}