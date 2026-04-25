using Microsoft.AspNetCore.Mvc;
using schoolApi.DTOs.ClassroomDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Interfaces;
using schoolApi.Mappers;

namespace schoolApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassroomController : ControllerBase
{
    private readonly IClassroomRepository _classroomRepo;
    public ClassroomController(IClassroomRepository classroomRepo)
    {
        _classroomRepo = classroomRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ClassroomQueryable query)
    {
        var classroomModels = await _classroomRepo.GetAllAsync(query);
        var classroomDto = classroomModels.Select(c => c.ToDTO());

        return Ok(classroomModels);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var classroomModel = await _classroomRepo.GetByIdAsync(id);

        if (classroomModel == null)
            return NotFound();

        return Ok(classroomModel);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ClassroomRequestDTO classroomRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var classroomModel = classroomRequest.ToClassroom();
        await _classroomRepo.PostAsync(classroomModel);

        return CreatedAtAction("GetById", new { id = classroomModel.Id }, classroomModel.ToDTO());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateClassroomRequestDTO updateClassroomRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var classroomModel = await _classroomRepo.UpdateAsync(id, updateClassroomRequest);

        if (classroomModel == null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var classroomModel = await _classroomRepo.DeleteAsync(id);

        if (classroomModel == null)
            return NotFound();

        return NoContent();
    }

}
