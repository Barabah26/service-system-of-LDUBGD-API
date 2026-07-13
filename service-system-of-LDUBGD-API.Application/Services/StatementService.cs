using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using service_system_of_LDUBGD_API.Application.Contracts;
using service_system_of_LDUBGD_API.Application.DTOs.Statement;
using service_system_of_LDUBGD_API.Common.Constants;
using service_system_of_LDUBGD_API.Common.Enums;
using service_system_of_LDUBGD_API.Common.Results;
using service_system_of_LDUBGD_API.Domain;
using System.Diagnostics.Metrics;
using System.Security.Claims;

namespace service_system_of_LDUBGD_API.Application.Services;

public class StatementService(ServiceSystemDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : IStatementService
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
            var userId = httpContextAccessor.HttpContext?
                .User
                .FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Result<GetStatementDto>.Failure(
                    new Error(
                        ErrorCodes.Forbid,
                        "User is not authenticated"));
            }

            var exists = await StatementExistsAsync(
                userId,
                statementDto.TypeOfStatement);

            if (exists)
            {
                return Result<GetStatementDto>.Failure(
                    new Error(
                        ErrorCodes.Conflict,
                        "You already have an active statement of this type."));
            }

            var statement = mapper.Map<Statement>(statementDto);

            statement.UserId = userId;
            statement.Status = StatementStatus.Pending;

            context.Statement.Add(statement);

            await context.SaveChangesAsync();

            var dto = mapper.Map<GetStatementDto>(statement);

            return Result<GetStatementDto>.Success(dto);
        }
        catch (Exception)
        {
            return Result<GetStatementDto>.Failure(
                new Error(
                    ErrorCodes.Failure,
                    "An unexpected error occurred while creating the statement."));
        }
    }

    public async Task<Result<IEnumerable<GetStatementListItemDto>>> FindByName(string fullName)
    {
        var statements = await context.Statement
                .Where(s => EF.Functions.Like(s.FullName, $"%{fullName}%"))
                .ProjectTo<GetStatementListItemDto>(mapper.ConfigurationProvider)
                .ToListAsync();


        if (statements == null)
        {
            return Result<IEnumerable<GetStatementListItemDto>>.Failure(new Error(ErrorCodes.Failure, "Statement was not found"));
        }


        return Result<IEnumerable<GetStatementListItemDto>>.Success(statements);
    }

    public async Task<bool> StatementExistsAsync(string userId, StatementType type)
    {
        return await context.Statement
            .AnyAsync(s =>
                s.UserId == userId &&
                s.TypeOfStatement == type &&
                (s.Status == StatementStatus.Pending ||
                 s.Status == StatementStatus.InProgress));
    }

    public async Task<Result<IEnumerable<GetStatementListItemDto>>> FindByNameAndStatus(string fullName, StatementStatus status)
    {
        var statements = await context.Statement
            .Where(s => s.FullName.Contains(fullName) && s.Status == status)
            .ProjectTo<GetStatementListItemDto>(mapper.ConfigurationProvider)
            .ToListAsync();

        if (!statements.Any())
        {
            return Result<IEnumerable<GetStatementListItemDto>>
                .Failure(new Error(ErrorCodes.NotFound, "Statements not found"));
        }

        return Result<IEnumerable<GetStatementListItemDto>>.Success(statements);
    }

    public async Task<Result<IEnumerable<GetStatementListItemDto>>> FindByStatusAndFaculty(StatementStatus status, string faculty)
    {
        var statements = await context.Statement
            .Where(s => s.Faculty.Contains(faculty) && s.Status == status)
            .ProjectTo<GetStatementListItemDto>(mapper.ConfigurationProvider)
            .ToListAsync();

        if (!statements.Any())
        {
            return Result<IEnumerable<GetStatementListItemDto>>
                .Failure(new Error(ErrorCodes.NotFound, "Statements not found"));
        }

        return Result<IEnumerable<GetStatementListItemDto>>.Success(statements);
    }

    public async Task<Result> UpdateStatus(int id, StatementStatus status)
    {
        var statement = await context.Statement.FindAsync(id);

        if (statement == null)
        {
            return Result.Failure(new Error(ErrorCodes.NotFound, "Statement not found"));
        }

        statement.Status = status;

        await context.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result<IEnumerable<GetStatementListItemDto>>> FindByUserId(string userId)
    {
        var statements = await context.Statement
         .Where(s => s.UserId == userId)
         .ProjectTo<GetStatementListItemDto>(mapper.ConfigurationProvider)
         .ToListAsync();

        return Result<IEnumerable<GetStatementListItemDto>>.Success(statements);
    }
}
