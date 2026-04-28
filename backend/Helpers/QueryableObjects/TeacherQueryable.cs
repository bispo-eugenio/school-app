namespace schoolApi.Helpers.QueryableObjects;

public class TeacherQueryable
{
    public string Name { get; set; } = "";
    public int? Age { get; set; } = null;
    public string? SortBy { get; set; } = null;
    public bool IsDescending { get; set; } = false;
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 25;
}
