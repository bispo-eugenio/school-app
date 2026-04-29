using Microsoft.AspNetCore.Mvc;
using schoolApi.Mappers;
using schoolApi.Helpers;
using schoolApi.DTOs.CourseSubjectMatterDtos;
using schoolApi.Interfaces;
using schoolApi.Helpers.QueryableObjects;

namespace schoolApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseSubjectMatterController : ControllerBase
{
    private readonly ICourseSubjectMatterService _courseSubjectMatterService;
    public CourseSubjectMatterController(ICourseSubjectMatterService courseSubjectMatterService)
    {
        _courseSubjectMatterService = courseSubjectMatterService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] CourseSubjectMatterQueryable query)
    {
        var courseSubjectMatterModel = await _courseSubjectMatterService.GetAll(query);
        var courseSubjectMatterModelDto = courseSubjectMatterModel.Select(c => c.ToDTO());

        return Ok(courseSubjectMatterModel);
    }

    [HttpGet("{dualId}")]
    public async Task<IActionResult> GetById([FromRoute] string dualId)
    {
        var listId = DualIdParse.TryParseId(dualId);
        if (listId == null)
            return NotFound();

        var courseSubjectMatterModel = await _courseSubjectMatterService.GetById(listId);

        if (courseSubjectMatterModel == null)
            return NotFound();

        return Ok(courseSubjectMatterModel.ToDTO());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CourseSubjectMatterRequestDTO courseSubjectMatterRequest)
    {
        var courseSubjectMatterModel = courseSubjectMatterRequest.ToCourseSubjectMatter();
        await _courseSubjectMatterService.Create(courseSubjectMatterModel);
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

        var courseSubjectMatterModel = _courseSubjectMatterService.Update(listId, updateCourseSubjectMatterRequest);

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

        var courseSubjectMatter = _courseSubjectMatterService.Delete(listId);

        if (courseSubjectMatter == null)
            return NotFound();

        return NoContent();
    }


}
