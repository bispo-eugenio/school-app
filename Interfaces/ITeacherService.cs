using schoolApi.DTOs.TeacherDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Models;

namespace schoolApi.Interfaces;

public interface ITeacherService
{
    public Task<List<Teacher>> GetAll(TeacherQueryable query);
    public Task<Teacher?> GetById(int id);
    public Task<Teacher> Create(Teacher teacher);
    public Task<Teacher?> Update(int id, UpdateTeacherRequestDTO updateTeacherRequest);
    public Task<Teacher?> Delete(int id);
}
