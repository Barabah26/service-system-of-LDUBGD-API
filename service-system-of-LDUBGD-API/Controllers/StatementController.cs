using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using service_system_of_LDUBGD_API.Domain;
using System.Diagnostics.Metrics;
using static NuGet.Packaging.PackagingConstants;

namespace service_system_of_LDUBGD_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatementController(ServiceSystemDbContext context) : ControllerBase
{
  
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Statement>>> GetStatements()
    {
        var statements = await context.Statement.ToListAsync();
        return Ok(statements);
    }

    [HttpPost]
    public async Task<ActionResult<Statement>> PostStatement(Statement statement)
    {
        context.Statement.Add(statement);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetStatements", new { id = statement.StatementId }, statement);
    }
}
