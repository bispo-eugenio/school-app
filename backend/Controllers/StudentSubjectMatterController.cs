using Microsoft.AspNetCore.Mvc;
using schoolApi.Dtos.StudentSubjectMatterDtos;
using schoolApi.Interfaces;
using schoolApi.Mappers;
using schoolApi.Helpers;
using schoolApi.Helpers.QueryableObjects;

namespace schoolApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentSubjectMatterController : ControllerBase
{
    private readonly IStudentSubjectMatterService _studentSubjectMatterService;
    public StudentSubjectMatterController(IStudentSubjectMatterService studentSubjectMatterService)
    {
        _studentSubjectMatterService = studentSubjectMatterService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] StudentSubjectMatterQueryable query)
    {
        var studentSubjectMatterModels = await _studentSubjectMatterService.GetAll(query);
        var studentSubjectMatterModelsDto = studentSubjectMatterModels.Select(s => s.ToDTO());
        return Ok(studentSubjectMatterModels);
    }

    [HttpGet("{dualId}")]
    public async Task<IActionResult> GetById([FromRoute] string dualId)
    {
        var listId = DualIdParse.TryParseId(dualId);

        if (listId == null)
            return NotFound();

        var studentSubjectMatterModel = await _studentSubjectMatterService.GetById(listId);

        if (studentSubjectMatterModel == null)
            return NotFound();

        return Ok(studentSubjectMatterModel.ToDTO());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] StudentSubjectMatterRequestDTO studentSubjectMatterRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var studentSubjectMatterModel = studentSubjectMatterRequest.ToStudentSubjectMatter();
        await _studentSubjectMatterService.Create(studentSubjectMatterModel);

        return CreatedAtAction(
        "GetById",
        new
        {
            dualId = $"{studentSubjectMatterModel.StudentId}-{studentSubjectMatterModel.SubjectMatterId}"
        },
        studentSubjectMatterModel.ToDTO());
    }

    [HttpPut("{dualId}")]
    public async Task<IActionResult> Update([FromRoute] string dualId, UpdateStudentSubjectMatterRequestDTO updateStudentSubjectMatterRequest)
    {
        var listId = DualIdParse.TryParseId(dualId);

        if (listId == null)
            return NotFound();

        var studentSubjectMatterModel = await _studentSubjectMatterService.Update(listId, updateStudentSubjectMatterRequest);

        if (studentSubjectMatterModel == null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{dualId}")]
    public async Task<IActionResult> Delete([FromRoute] string dualId)
    {
        var listId = DualIdParse.TryParseId(dualId);

        if (listId == null)
            return NotFound();

        var studentSubjectMatterModel = await _studentSubjectMatterService.Delete(listId);

        if (studentSubjectMatterModel == null)
            return NotFound();

        return NoContent();
    }

}
