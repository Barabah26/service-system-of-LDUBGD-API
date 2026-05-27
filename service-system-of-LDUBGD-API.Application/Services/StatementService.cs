using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using service_system_of_LDUBGD_API.Application.Contracts;
using service_system_of_LDUBGD_API.Application.DTOs.Statement;
using service_system_of_LDUBGD_API.Common.Constants;
using service_system_of_LDUBGD_API.Common.Results;
using service_system_of_LDUBGD_API.Domain;
using System.Diagnostics.Metrics;

namespace service_system_of_LDUBGD_API.Application.Services;

public class StatementService(ServiceSystemDbContext context, IMapper mapper) : IStatementService
{
    public async Task<Result<IEnumerable<GetStatementListItemDto>>> GetStatements()
    {

        var statements = await context.Statement
            .ProjectTo<GetStatementListItemDto>(mapper.ConfigurationProvider)
            .ToListAsync();

        return Result<IEnumerable<GetStatementListItemDto>>.Success(statements);
    }

    public async Task<Result<GetStatementDto>> CreateStatement(CreateStatementDto statementDto)
    {
        try
        {
            var exists = await StatementExistsAsync(statementDto.FullName);
            if (exists)
            {
                return Result<GetStatementDto>.Failure(new Error(ErrorCodes.Conflict, $"Statement with name '{statementDto.FullName}' already exists."));
            }

            var statement = mapper.Map<Statement>(statementDto);
            statement.UserId = "11111111-1111-1111-1111-111111111111";
            context.Statement.Add(statement);
            await context.SaveChangesAsync();

            var dto = await context.Statement
                .Where(s => s.StatementId == statement.StatementId)
                .ProjectTo<GetStatementDto>(mapper.ConfigurationProvider)
                .FirstAsync();

            return Result<GetStatementDto>.Success(dto);
        }
        catch
        {
            return Result<GetStatementDto>.Failure(new Error(ErrorCodes.Failure, "An unexpected error occurred while creating the statement."));
        }

    }

    public async Task<bool> StatementExistsAsync(int id)
    {
        return await context.Statement.AnyAsync(e => e.StatementId == id);
    }

    public async Task<bool> StatementExistsAsync(string fullName)
    {
        return await context.Statement
            .AnyAsync(c => c.FullName.ToLower().Trim() == fullName.ToLower().Trim());
    }

}
