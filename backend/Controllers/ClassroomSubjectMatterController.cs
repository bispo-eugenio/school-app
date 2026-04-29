using Microsoft.AspNetCore.Mvc;
using schoolApi.DTOs.ClassroomSubjectMatterDtos;
using schoolApi.Helpers;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Interfaces;
using schoolApi.Mappers;

namespace schoolApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassroomSubjectMatterController : ControllerBase
{
    private readonly IClassroomSubjectMatterService _classroomSubjectMatterService;
    public ClassroomSubjectMatterController(IClassroomSubjectMatterService classroomSubjectMatterService)
    {
        _classroomSubjectMatterService = classroomSubjectMatterService;
    }


    [HttpGet]
    public async Task<IActionResult>
    GetAll([FromQuery] ClassroomSubjectMatterQueryable query)
    {
        var classroomSubjectMatterModels =
        await _classroomSubjectMatterService.GetAll(query);
        var classroomSubjectMatterModelsDto =
        classroomSubjectMatterModels.Select(csm => csm.ToDTO());

        return Ok(classroomSubjectMatterModelsDto);
    }

    [HttpGet("{dualId}")]
    public async Task<IActionResult> GetById([FromRoute] string dualId)
    {
        var listId = DualIdParse.TryParseId(dualId);

        if (listId == null)
            return NotFound();

        var classroomSubjectMatterModel =
        await _classroomSubjectMatterService.GetById(listId);

        if (classroomSubjectMatterModel == null)
            return NotFound();

        return Ok(classroomSubjectMatterModel.ToDTO());
    }

    [HttpPost]
    public async Task<IActionResult>
    Post([FromBody] ClassroomSubjectMatterRequestDTO
    classroomSubjectMatterRequest)
    {
        var classroomSubjectMatterModel = classroomSubjectMatterRequest
        .ToClassroomSubjectMatter();
        await _classroomSubjectMatterService.Create(classroomSubjectMatterModel);

        return CreatedAtAction("GetById",
            new
            {
                dualId = $"{classroomSubjectMatterModel.ClassroomId}-" +
                $"{classroomSubjectMatterModel.SubjectMatterId}"
            },
            classroomSubjectMatterModel.ToDTO());
    }

    [HttpPut("{dualId}")]
    public async Task<IActionResult> Update([FromRoute] string dualId,
    UpdateClassroomSubjectMatterRequestDTO updateClassroomSubjectMatterRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var listId = DualIdParse.TryParseId(dualId);

        if (listId == null)
            return NotFound();

        var classroomSubjectMatterModel = _classroomSubjectMatterService
        .Update(listId, updateClassroomSubjectMatterRequest);

        if (classroomSubjectMatterModel == null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{dualId}")]
    public async Task<IActionResult> Delete([FromRoute] string dualId)
    {
        var listId = DualIdParse.TryParseId(dualId);

        if (listId == null)
            return NotFound();

        var classroomSubjectMatterModel = _classroomSubjectMatterService
        .Delete(listId);

        if (classroomSubjectMatterModel == null)
            return NotFound();

        return NoContent();
    }

}
