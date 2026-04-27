using Microsoft.AspNetCore.Mvc;
using schoolApi.DTOs.SubjectMatterDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Mappers;
namespace schoolApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubjectMatterController : ControllerBase
{
    private readonly ISubjectMatterRepository _subjectMatterRepo;
    public SubjectMatterController(ISubjectMatterRepository subjectMatterRepo)
    {
        _subjectMatterRepo = subjectMatterRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] SubjectMatterQueryable query)
    {
        var subjectMatterModels = await _subjectMatterRepo.GetAllAsync(query);
        var subjectMatterModelsDto = subjectMatterModels.Select(s => s.ToDTO());

        return Ok(subjectMatterModelsDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var subjectMatterModel = await _subjectMatterRepo.GetByIdAsync(id);
        if (subjectMatterModel == null)
            return NotFound();

        return Ok(subjectMatterModel.ToDTO());
    }

    [HttpGet("{id:int}/courses")]
    public async Task<IActionResult> GetCoursesBySubjectMatter([FromRoute] int id)
    {
        var coursesModel = await _subjectMatterRepo.GetCoursesBySubjectMatter(id);
        return Ok(coursesModel);
    }

    [HttpGet("{id:int}/students")]
    public async Task<IActionResult> GetStudentsBySubjectMatter([FromRoute] int id)
    {
        var studentsModel = await _subjectMatterRepo.GetCoursesBySubjectMatter(id);
        return Ok(studentsModel);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SubjectMatterRequestDTO subjectMatterRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var subjectMatterModel = subjectMatterRequest.ToSubjectMatter();
        await _subjectMatterRepo.PostAsync(subjectMatterModel);

        return CreatedAtAction("GetById", new { id = subjectMatterModel.Id }, subjectMatterModel.ToDTO());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSubjectMatterRequestDTO updateSubjectMatterRequest)
    {
        var subjectMatterModel = await _subjectMatterRepo.UpdateAsync(id, updateSubjectMatterRequest);

        if (subjectMatterModel == null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var subjectMatterModel = await _subjectMatterRepo.DeleteAsync(id);

        if (subjectMatterModel == null)
            return NotFound();

        return NoContent();
    }

}
