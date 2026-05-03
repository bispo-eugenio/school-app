using schoolApi.DTOs.ClassroomDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Models;

namespace schoolApi.Interfaces;

public interface IClassroomService
{
    public Task<List<Classroom>> GetAll(ClassroomQueryable query);
    public Task<Classroom?> GetById(int id);
    public Task<Classroom> Create(Classroom classroom);
    public Task<Classroom?> Update(int id, UpdateClassroomRequestDTO updateClassroomRequest);
    public Task<Classroom?> Delete(int id);
}
