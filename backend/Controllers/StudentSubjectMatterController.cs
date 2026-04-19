using Microsoft.AspNetCore.Mvc;
using schoolApi.Dtos.StudentSubjectMatterDtos;
using schoolApi.Interfaces;
using schoolApi.Mappers;
using schoolApi.Helpers;

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
    public async Task<IActionResult> GetAll()
    {
        var studentSubjectMatterModels = await _studentSubjectMatterRepo.GetAllAsync();
        var studentSubjectMatterModelsDto = studentSubjectMatterModels.Select(s => s.ToDTO());
        return Ok(studentSubjectMatterModels);
    }

    [HttpGet("{dualId}")]
    public async Task<IActionResult> GetById([FromRoute] string dualId)
    {
        var studentSubjectMatterModel = await _studentSubjectMatterRepo.GetByIdAsync(DualParseId.TryParseId(dualId));

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

        return CreatedAtAction("GetById",
        new
        {
            id = $"{studentSubjectMatterModel.StudentId}-{studentSubjectMatterModel.SubjectMatterId}"
        },
        studentSubjectMatterModel.ToDTO());
    }
}
