using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using service_system_of_LDUBGD_API.Application.Contracts;
using service_system_of_LDUBGD_API.Application.DTOs.Statement;
using service_system_of_LDUBGD_API.Common.Enums;
using service_system_of_LDUBGD_API.Domain;
using System.Diagnostics.Metrics;
using System.Linq;
using static NuGet.Packaging.PackagingConstants;

namespace service_system_of_LDUBGD_API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
[Authorize]
public class StatementController(IStatementService statementService) : BaseApiController
{
  
    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<IEnumerable<GetStatementListItemDto>>> GetStatements()
    {

        var results = await statementService.GetStatements();
        return ToActionResult(results);
    }

    [HttpGet("search")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<IEnumerable<GetStatementListItemDto>>> FindStatementByName([FromQuery] string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            return BadRequest("Name is required");
        }

        var results = await statementService.FindByName(fullName);
        return ToActionResult(results);
    }

    [HttpPost("createStatement")]
    [Authorize(Roles = "Student")]
    public async Task<ActionResult<GetStatementDto>> PostStatement(CreateStatementDto statementDto)
    {
        var result = await statementService.CreateStatement(statementDto);
        if (!result.IsSuccess) return MapErrorsToResponse(result.Errors);

        return CreatedAtAction(nameof(GetStatements), new { id = result.Value!.StatementId }, result.Value);

    }

    [HttpGet("findByFullNameAndStatus")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<IEnumerable<GetStatementListItemDto>>> FindStatementByNameAndStatus([FromQuery] string fullName, [FromQuery] StatementStatus status)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            return BadRequest("Name is required");
        }

        var results = await statementService.FindByNameAndStatus(fullName, status);
        return ToActionResult(results);
    }

    [HttpGet("findByFacultyAndStatus")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<IEnumerable<GetStatementListItemDto>>> FindStatementByFacultyAndStatus([FromQuery] string faculty, [FromQuery] StatementStatus status)
    {
        if (string.IsNullOrWhiteSpace(faculty))
        {
            return BadRequest("Name is required");
        }

        var results = await statementService.FindByStatusAndFaculty(status, faculty);
        return ToActionResult(results);
    }

    [HttpPatch("update-status")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> UpdateStatus(UpdateStatementDto dto)
    {
        var result = await statementService.UpdateStatus(dto.StatementId, dto.Status);

        return ToActionResult(result);
    }

}
