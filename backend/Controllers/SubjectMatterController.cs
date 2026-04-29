using Microsoft.AspNetCore.Mvc;
using schoolApi.DTOs.SubjectMatterDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Interfaces;
using schoolApi.Mappers;
namespace schoolApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubjectMatterController : ControllerBase
{
    private readonly ISubjectMatterService _subjectMatterService;
    public SubjectMatterController(ISubjectMatterService subjectMatterService)
    {
        _subjectMatterService = subjectMatterService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] SubjectMatterQueryable query)
    {
        var subjectMatterModels = await _subjectMatterService.GetAll(query);
        var subjectMatterModelsDto = subjectMatterModels.Select(s => s.ToDTO());

        return Ok(subjectMatterModelsDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var subjectMatterModel = await _subjectMatterService.GetById(id);
        if (subjectMatterModel == null)
            return NotFound();

        return Ok(subjectMatterModel.ToDTO());
    }

    [HttpGet("{id:int}/courses")]
    public async Task<IActionResult> GetCoursesBySubjectMatter([FromRoute] int id)
    {
        var coursesModel = await _subjectMatterService.GetCoursesBySubjectMatter(id);
        return Ok(coursesModel);
    }

    [HttpGet("{id:int}/students")]
    public async Task<IActionResult> GetStudentsBySubjectMatter([FromRoute] int id)
    {
        var studentsModel = await _subjectMatterService.GetCoursesBySubjectMatter(id);
        return Ok(studentsModel);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SubjectMatterRequestDTO subjectMatterRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var subjectMatterModel = subjectMatterRequest.ToSubjectMatter();
        await _subjectMatterService.Create(subjectMatterModel);

        return CreatedAtAction("GetById", new { id = subjectMatterModel.Id }, subjectMatterModel.ToDTO());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSubjectMatterRequestDTO updateSubjectMatterRequest)
    {
        var subjectMatterModel = await _subjectMatterService.Update(id, updateSubjectMatterRequest);

        if (subjectMatterModel == null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var subjectMatterModel = await _subjectMatterService.Delete(id);

        if (subjectMatterModel == null)
            return NotFound();

        return NoContent();
    }

}
