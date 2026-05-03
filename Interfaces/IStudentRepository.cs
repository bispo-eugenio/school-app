using schoolApi.DTOs.StudentDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Models;

namespace schoolApi.Interfaces;

public interface IStudentRepository
{
    public Task<List<Student>> GetAllAsync(StudentQueryable query);
    public Task<Student?> GetByIdAsync(int id);
    public Task<List<SubjectMatter>> GetSubjectMattersByStudent(int id);
    public Task<Student> PostAsync(Student student);
    public Task<Student?> UpdateAsync(int id, UpdateStudentRequestDTO updateStudentRequest);
    public Task<Student?> DeleteAsync(int id);
}
