using schoolApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using schoolApi.Mappers;
using schoolApi.DTOs.TeacherDtos;
using Microsoft.EntityFrameworkCore;
using schoolApi.Helpers.QueryableObjects;
using Microsoft.AspNetCore.Authorization;

namespace schoolApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _teacherService;
    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] TeacherQueryable query)
    {
        var teacherModels = await _teacherService.GetAll(query);
        var teacherModelsDto = teacherModels.Select(t => t.ToDTO());

        return Ok(teacherModelsDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var teacherModel = await _teacherService.GetById(id);

        if (teacherModel == null)
            return NotFound();

        return Ok(teacherModel.ToDTO());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TeacherRequestDTO teacherRequest)
    {

        var teacherModel = teacherRequest.ToTeacher();
        await _teacherService.Create(teacherModel);

        return CreatedAtAction("GetById", new { id = teacherModel.Id }, teacherModel.ToDTO());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTeacherRequestDTO updateTeacherRequest)
    {
        var teacherModel = await _teacherService.Update(id, updateTeacherRequest);

        if (teacherModel == null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var teacherModel = await _teacherService.Delete(id);

        if (teacherModel == null)
            return NotFound();

        return NoContent();
    }

}
