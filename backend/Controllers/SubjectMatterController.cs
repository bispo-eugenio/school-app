using Microsoft.AspNetCore.Mvc;
using schoolApi.DTOs.SubjectMatterDtos;
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
    public async Task<IActionResult> GetAll()
    {
        var subjectMatterModels = await _subjectMatterRepo.GetAllAsync();
        var subjectMatterModelsDto = subjectMatterModels.Select(s => s.ToDTO());

        return Ok(subjectMatterModels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var subjectMatterModel = await _subjectMatterRepo.GetByIdAsync(id);
        if(subjectMatterModel == null)
            return NotFound();

        return Ok(subjectMatterModel);
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
}
