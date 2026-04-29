using schoolApi.DTOs.StudentDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Models;

namespace schoolApi.Interfaces;

public interface IStudentService
{
    public Task<List<Student>> GetAll(StudentQueryable query);
    public Task<Student?> GetById(int id);
    public Task<List<SubjectMatter>> GetSubjectMattersByStudent(int id);
    public Task<Student> Create(Student student);
    public Task<Student?> Update
    (int id, UpdateStudentRequestDTO updateStudentRequest);
    public Task<Student?> Delete(int id);
}
