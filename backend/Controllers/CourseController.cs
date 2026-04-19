using Microsoft.AspNetCore.Mvc;
using schoolApi.DTOs.CourseDtos;
using schoolApi.Interfaces;
using schoolApi.Mappers;

namespace schoolApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseRepository _courseRepo;
    public CourseController(ICourseRepository courseRepository)
    {
        _courseRepo = courseRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var courseModels = await _courseRepo.GetAllAsync();
        var courseModelsDto = courseModels.Select(c => c.ToDTO());

        return Ok(courseModels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var courseModel = await _courseRepo.GetByIdAsync(id);

        if (courseModel == null)
            return NotFound();

        return Ok(courseModel);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CourseRequestDTO courseRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var courseModel = courseRequest.ToCourse();
        await _courseRepo.PostAsync(courseModel);

        return CreatedAtAction("GetById", new { id = courseModel.Id }, courseModel.ToDTO());
    }

}
