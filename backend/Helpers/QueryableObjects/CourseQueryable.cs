namespace schoolApi.Helpers.QueryableObjects;

public class CourseQueryable
{
    public string Name { get; set; } = "";
    public string? SortBy { get; set; } = null;
    public bool IsDescending { get; set; } = false;
}
