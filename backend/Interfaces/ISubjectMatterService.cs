using schoolApi.DTOs.SubjectMatterDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Models;

namespace schoolApi.Interfaces;

public interface ISubjectMatterService
{
    public Task<List<SubjectMatter>> GetAll(SubjectMatterQueryable query);
    public Task<SubjectMatter?> GetById(int id);
    public Task<List<Course>> GetCoursesBySubjectMatter(int id);
    public Task<List<Student>> GetStudentsBySubjectMatter(int id);
    public Task<SubjectMatter> Create(SubjectMatter subjectMatter);
    public Task<SubjectMatter?> Update(int id, UpdateSubjectMatterRequestDTO updateSubjectMatterRequest);
    public Task<SubjectMatter?> Delete(int id);
}
