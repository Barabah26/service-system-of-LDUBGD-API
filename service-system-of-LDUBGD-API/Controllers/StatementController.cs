using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using service_system_of_LDUBGD_API.Application.Contracts;
using service_system_of_LDUBGD_API.Application.DTOs.Statement;
using service_system_of_LDUBGD_API.Domain;
using System.Diagnostics.Metrics;
using System.Linq;
using static NuGet.Packaging.PackagingConstants;

namespace service_system_of_LDUBGD_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatementController(IStatementService statementService) : BaseApiController
{
  
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetStatementListItemDto>>> GetStatements()
    {

        var results = await statementService.GetStatements();
        return ToActionResult(results);
    }

    [HttpPost]
    public async Task<ActionResult<GetStatementDto>> PostStatement(CreateStatementDto statementDto)
    {
        var result = await statementService.CreateStatement(statementDto);
        if (!result.IsSuccess) return MapErrorsToResponse(result.Errors);

        return CreatedAtAction(nameof(GetStatements), new { id = result.Value!.StatementId }, result.Value);

    }
}
