using schoolApi.Models;

namespace schoolApi.Interfaces;

public interface IClassroomRepository
{
    public Task<List<Classroom>> GetAll();
    public Task<Classroom?> GetByIdAsync(int id);
    public Task<Classroom> PostAsync(Classroom classroom);
}
