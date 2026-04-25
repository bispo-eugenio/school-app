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
    private readonly IStudentSubjectMatterRepository _studentSubjectMatterRepo;
    public StudentSubjectMatterController(IStudentSubjectMatterRepository studentSubjectMatterRepo)
    {
        _studentSubjectMatterRepo = studentSubjectMatterRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] StudentSubjectMatterQueryable query)
    {
        var studentSubjectMatterModels = await _studentSubjectMatterRepo.GetAllAsync(query);
        var studentSubjectMatterModelsDto = studentSubjectMatterModels.Select(s => s.ToDTO());
        return Ok(studentSubjectMatterModels);
    }

    [HttpGet("{dualId}")]
    public async Task<IActionResult> GetById([FromRoute] string dualId)
    {
        var listId = DualIdParse.TryParseId(dualId);

        if (listId == null)
            return NotFound();

        var studentSubjectMatterModel = await _studentSubjectMatterRepo.GetByIdAsync(listId);

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
        await _studentSubjectMatterRepo.PostAsync(studentSubjectMatterModel);

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

        var studentSubjectMatterModel = await _studentSubjectMatterRepo.UpdateAsync(listId, updateStudentSubjectMatterRequest);

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

        var studentSubjectMatterModel = await _studentSubjectMatterRepo.DeleteAsync(listId);

        if (studentSubjectMatterModel == null)
            return NotFound();

        return NoContent();
    }

}
