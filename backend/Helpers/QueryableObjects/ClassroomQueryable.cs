namespace schoolApi.Helpers.QueryableObjects;

public class ClassroomQueryable
{
    public string Name { get; set; } = "";
    public string? SortBy { get; set; } = null;
    public bool IsDescending { get; set; } = false;
}
