using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using schoolApi.DTOs.ClassroomDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Interfaces;
using schoolApi.Mappers;

namespace schoolApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ClassroomController : ControllerBase
{
    private readonly IClassroomService _classroomService;
    public ClassroomController(IClassroomService classroomService)
    {
        _classroomService = classroomService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ClassroomQueryable query)
    {
        var classroomModels = await _classroomService.GetAll(query);
        var classroomDto = classroomModels.Select(c => c.ToDTO());

        return Ok(classroomDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var classroomModel = await _classroomService.GetById(id);

        if (classroomModel == null)
            return NotFound();

        return Ok(classroomModel.ToDTO());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ClassroomRequestDTO classroomRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var classroomModel = classroomRequest.ToClassroom();
        await _classroomService.Create(classroomModel);

        return CreatedAtAction("GetById", new { id = classroomModel.Id }, classroomModel.ToDTO());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateClassroomRequestDTO updateClassroomRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var classroomModel = await _classroomService.Update(id, updateClassroomRequest);

        if (classroomModel == null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var classroomModel = await _classroomService.Delete(id);

        if (classroomModel == null)
            return NotFound();

        return NoContent();
    }

}
