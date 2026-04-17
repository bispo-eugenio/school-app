using schoolApi.Models;

namespace schoolApi.Interfaces;

public interface ICourseRepository
{
    public Task<List<Course>> GetAll();
    public Task<Course?> GetByIdAsync(int id);
    public Task<Course> PostAsync(Course course);
}
