using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using service_system_of_LDUBGD_API.Application.DTOs.Statement;
using service_system_of_LDUBGD_API.Domain;
using System.Diagnostics.Metrics;
using System.Linq;
using static NuGet.Packaging.PackagingConstants;

namespace service_system_of_LDUBGD_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatementController(ServiceSystemDbContext context) : ControllerBase
{
  
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetStatementListItemDto>>> GetStatements()
    {

        var statements = await context.Statement
            .Select(s => new GetStatementListItemDto(
                s.StatementId,
                s.FullName,
                s.TypeOfStatement,
                s.Group
            ))
            .ToListAsync();
        return Ok(statements);
    }

    [HttpPost]
    public async Task<ActionResult<GetStatementDto>> PostStatement(CreateStatementDto statementDto)
    {
        var statement = new Statement
        {
            FullName = statementDto.FullName,
            YearBirthday = statementDto.DateOfBirth,
            Group = statementDto.Group,
            PhoneNumber = statementDto.PhoneNumber,
            Faculty = statementDto.Faculty,
            TypeOfStatement = statementDto.TypeOfStatement,
            UserId = statementDto.UserId,
        };
        
        context.Statement.Add(statement);
        await context.SaveChangesAsync();

        var resultDto = new GetStatementDto(statement.StatementId, statement.FullName, statement.YearBirthday, statement.Group, statement.PhoneNumber, statement.Faculty, statement.TypeOfStatement, statement.UserId);

        return CreatedAtAction(nameof(GetStatements), new { id = statement.StatementId}, statementDto);
    }
}
