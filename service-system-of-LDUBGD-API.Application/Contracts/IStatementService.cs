using service_system_of_LDUBGD_API.Application.DTOs.Statement;
using service_system_of_LDUBGD_API.Common.Enums;
using service_system_of_LDUBGD_API.Common.Results;
using service_system_of_LDUBGD_API.Domain.Migrations;

namespace service_system_of_LDUBGD_API.Application.Contracts;

public interface IStatementService
{
    Task<Result<GetStatementDto>> CreateStatement(CreateStatementDto statementDto);
    Task<Result<IEnumerable<GetStatementListItemDto>>> GetStatements();
    Task<Result<IEnumerable<GetStatementListItemDto>>> FindByName(string fullName);
    Task<Result<IEnumerable<GetStatementListItemDto>>> FindByUserId(string userId);
    Task<Result<IEnumerable<GetStatementListItemDto>>> FindByNameAndStatus(string fullName, StatementStatus status);
    Task<Result<IEnumerable<GetStatementListItemDto>>> FindByStatusAndFaculty(StatementStatus status, String faculty);
    Task<Result> UpdateStatus(int id, StatementStatus status);
}