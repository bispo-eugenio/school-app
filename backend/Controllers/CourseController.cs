using Microsoft.AspNetCore.Mvc;
using schoolApi.DTOs.CourseDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Interfaces;
using schoolApi.Mappers;

namespace schoolApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;
    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] CourseQueryable query)
    {
        var courseModels = await _courseService.GetAll(query);
        var courseModelsDto = courseModels.Select(c => c.ToDTO());

        return Ok(courseModelsDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var courseModel = await _courseService.GetById(id);

        if (courseModel == null)
            return NotFound();

        return Ok(courseModel);
    }

    [HttpGet("{id:int}/subjectmatters")]
    public async Task<IActionResult> GetSubjectMattersByCourse([FromRoute] int id)
    {
        var subjectMatterModel = await _courseService.GetSubjectMattersByCourse(id);
        return Ok(subjectMatterModel);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CourseRequestDTO courseRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var courseModel = courseRequest.ToCourse();
        await _courseService.Create(courseModel);

        return CreatedAtAction("GetById", new { id = courseModel.Id }, courseModel.ToDTO());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCourseRequestDTO updateCourseRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var courseModel = await _courseService.Update(id, updateCourseRequest);

        if (courseModel == null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var courseModel = await _courseService.Delete(id);

        if (courseModel == null)
            return NotFound();

        return NoContent();
    }

}
