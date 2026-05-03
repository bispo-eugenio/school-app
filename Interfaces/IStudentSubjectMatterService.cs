using schoolApi.Dtos.StudentSubjectMatterDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Models;

namespace schoolApi.Interfaces;

public interface IStudentSubjectMatterService
{
    public Task<List<StudentSubjectMatter>> GetAll
    (StudentSubjectMatterQueryable query);
    public Task<StudentSubjectMatter?> GetById(List<int> dualId);
    public Task<StudentSubjectMatter> Create
    (StudentSubjectMatter studentSubjectMatter);
    public Task<StudentSubjectMatter?> Update(List<int> dualId,
    UpdateStudentSubjectMatterRequestDTO updateStudentSubjectMatterRequest);
    public Task<StudentSubjectMatter?> Delete(List<int> dualId);
}
