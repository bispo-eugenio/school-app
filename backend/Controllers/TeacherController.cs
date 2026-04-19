using schoolApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using schoolApi.Mappers;
using schoolApi.DTOs.TeacherDtos;

namespace schoolApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeacherController : ControllerBase
{
    private readonly ITeacherRepository _teacherRepo;
    public TeacherController(ITeacherRepository teacherRepo)
    {
        _teacherRepo = teacherRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var teacherModels = await _teacherRepo.GetAllAsync();
        var teacherModelsDto = teacherModels.Select(t => t.ToDTO());

        return Ok(teacherModelsDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var teacherModel = await _teacherRepo.GetByIdAsync(id);

        if (teacherModel == null)
            return NotFound();

        return Ok(teacherModel);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TeacherRequestDTO teacherRequest)
    {

        var teacherModel = teacherRequest.ToTeacher();
        await _teacherRepo.PostAsync(teacherModel);

        return CreatedAtAction("GetById", new { id = teacherModel.Id }, teacherModel.ToDTO());
    }
}
