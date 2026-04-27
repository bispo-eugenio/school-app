using schoolApi.DTOs.ClassroomSubjectMatterDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Models;

namespace schoolApi.Interfaces;

public interface IClassroomSubjectMatterRepository
{
    public Task<List<ClassroomSubjectMatter>> GetAllAsync(ClassroomSubjectMatterQueryable query);
    public Task<ClassroomSubjectMatter?> GetByIdAsync(List<int> dualId);
    public Task<ClassroomSubjectMatter>
    PostAsync(ClassroomSubjectMatter course);
    public Task<ClassroomSubjectMatter?> UpdateAsync(List<int> dualId,
    UpdateClassroomSubjectMatterRequestDTO
    updateClassroomSubjectMatterRequest);
    public Task<ClassroomSubjectMatter?> DeleteAsync(List<int> dualId);
}
