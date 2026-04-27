namespace schoolApi.Helpers.QueryableObjects;

public class TeacherQueryable
{
    public string Name { get; set; } = "";
    public int? Age { get; set; } = null;
    public string? SortBy { get; set; } = null;
    public bool IsDescending { get; set; } = false;
}
