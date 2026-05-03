using schoolApi.DTOs.ClassroomDtos;
using schoolApi.Helpers.QueryableObjects;
using schoolApi.Models;

namespace schoolApi.Interfaces;

public interface IClassroomRepository
{
    public Task<List<Classroom>> GetAllAsync(ClassroomQueryable query);
    public Task<Classroom?> GetByIdAsync(int id);
    public Task<Classroom> PostAsync(Classroom classroom);
    public Task<Classroom?> UpdateAsync(int id, UpdateClassroomRequestDTO updateClassroomRequest);
    public Task<Classroom?> DeleteAsync(int id);
}
