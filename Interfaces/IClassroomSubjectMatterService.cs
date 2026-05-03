using schoolApi.DTOs.ClassroomSubjectMatterDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Models;

namespace schoolApi.Interfaces;

public interface IClassroomSubjectMatterService
{
    public Task<List<ClassroomSubjectMatter>> GetAll(
    ClassroomSubjectMatterQueryable query);
    public Task<ClassroomSubjectMatter?> GetById(List<int> dualId);
    public Task<ClassroomSubjectMatter>
    Create(ClassroomSubjectMatter classroomSubjectMatter);
    public Task<ClassroomSubjectMatter?> Update(List<int> dualId,
    UpdateClassroomSubjectMatterRequestDTO
    updateClassroomSubjectMatterRequest);
    public Task<ClassroomSubjectMatter?> Delete(List<int> dualId);
}
