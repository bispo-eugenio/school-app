using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using schoolApi.DTOs.StudentDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Interfaces;
using schoolApi.Mappers;

namespace schoolApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] StudentQueryable query)
    {
        var studentModels = await _studentService.GetAll(query);
        var studentModelsDto = studentModels.Select(s => s.ToDTO());
        return Ok(studentModels);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var studentModel = await _studentService.GetById(id);

        if (studentModel == null)
            return NotFound();

        return Ok(studentModel);
    }

    [HttpGet("{id:int}/subjectMatters")]
    public async Task<IActionResult> GetSubjectMatterByStudent([FromRoute] int id)
    {
        var subjectMatterModel = await _studentService.GetSubjectMattersByStudent(id);
        return Ok(subjectMatterModel);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] StudentRequestDTO studentRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var studentModel = studentRequest.ToStudent();
        await _studentService.Create(studentModel);

        return CreatedAtAction("GetById", new { id = studentModel.Id }, studentModel.ToDTO());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStudentRequestDTO updateStudentRequest)
    {
        var studentModel = await _studentService.Update(id, updateStudentRequest);

        if (studentModel == null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var studentModel = await _studentService.Delete(id);

        if (studentModel == null)
            return NotFound();

        return NoContent();
    }

}
