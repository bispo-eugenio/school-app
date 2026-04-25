using Microsoft.AspNetCore.Mvc;
using schoolApi.Mappers;
using schoolApi.Helpers;
using schoolApi.DTOs.CourseSubjectMatterDtos;
using schoolApi.Interfaces;

namespace schoolApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseSubjectMatterController : ControllerBase
{
    private readonly ICourseSubjectMatterRepository _courseSubjectMatterRepo;
    public CourseSubjectMatterController(ICourseSubjectMatterRepository courseSubjectMatterRepo)
    {
        _courseSubjectMatterRepo = courseSubjectMatterRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var courseSubjectMatterModel = await _courseSubjectMatterRepo.GetAllAsync();
        var courseSubjectMatterModelDto = courseSubjectMatterModel.Select(c => c.ToDTO());

        return Ok(courseSubjectMatterModel);
    }

    [HttpGet("{dualId}")]
    public async Task<IActionResult> GetById([FromRoute] string dualId)
    {
        var listId = DualIdParse.TryParseId(dualId);
        if (listId == null)
            return NotFound();

        var courseSubjectMatterModel = await _courseSubjectMatterRepo.GetByIdAsync(listId);

        if (courseSubjectMatterModel == null)
            return NotFound();

        return Ok(courseSubjectMatterModel.ToDTO());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CourseSubjectMatterRequestDTO courseSubjectMatterRequest)
    {
        var courseSubjectMatterModel = courseSubjectMatterRequest.ToCourseSubjectMatter();
        await _courseSubjectMatterRepo.PostAsync(courseSubjectMatterModel);
        return CreatedAtAction(
        "GetById",
        new
        {
            dualId = $"{courseSubjectMatterModel.CourseId}-{courseSubjectMatterModel.SubjectMatterId}"
        },
        courseSubjectMatterModel.ToDTO());
    }

    [HttpPut("{dualId}")]
    public async Task<IActionResult> Update([FromRoute] string dualId, [FromBody] UpdateCourseSubjectMatterRequestDTO updateCourseSubjectMatterRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var listId = DualIdParse.TryParseId(dualId);

        if (listId == null)
            return NotFound();

        var courseSubjectMatterModel = _courseSubjectMatterRepo.UpdateAsync(listId, updateCourseSubjectMatterRequest);

        if (courseSubjectMatterModel == null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{dualId}")]
    public async Task<IActionResult> Delete([FromRoute] string dualId)
    {
        var listId = DualIdParse.TryParseId(dualId);

        if (listId == null)
            return NotFound();

        var courseSubjectMatter = _courseSubjectMatterRepo.DeleteAsync(listId);

        if (courseSubjectMatter == null)
            return NotFound();

        return NoContent();
    }


}
