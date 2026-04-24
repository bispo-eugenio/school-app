using Microsoft.AspNetCore.Mvc;
using schoolApi.DTOs.StudentDtos;
using schoolApi.Interfaces;
using schoolApi.Mappers;

namespace schoolApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _studentRepo;
    public StudentController(IStudentRepository studentRepo)
    {
        _studentRepo = studentRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var studentModels = await _studentRepo.GetAllAsync();
        var studentModelsDto = studentModels.Select(s => s.ToDTO());
        return Ok(studentModels);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var studentModel = await _studentRepo.GetByIdAsync(id);

        if (studentModel == null)
            return NotFound();

        return Ok(studentModel);
    }

    [HttpGet("{id:int}/subjectMatter")]
    public async Task<IActionResult> GetSubjectMatterByStudent([FromRoute] int id)
    {
        var subjectMatterModel = await _studentRepo.GetSubjectMattersByStudent(id);
        return Ok(subjectMatterModel);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] StudentRequestDTO studentRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var studentModel = studentRequest.ToStudent();
        await _studentRepo.PostAsync(studentModel);

        return CreatedAtAction("GetById", new { id = studentModel.Id }, studentModel.ToDTO());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStudentRequestDTO updateStudentRequest)
    {
        var studentModel = await _studentRepo.UpdateAsync(id, updateStudentRequest);

        if (studentModel == null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var studentModel = await _studentRepo.DeleteAsync(id);

        if (studentModel == null)
            return NotFound();

        return NoContent();
    }

}
