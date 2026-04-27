namespace schoolApi.Helpers.QueryableObjects;

public class SubjectMatterQueryable
{
    public string Name { get; set; } = "";
    public int? TeacherId { get; set; } = null;
    public string? SortBy { get; set; } = null;
    public bool IsDescending { get; set; } = false;
}
