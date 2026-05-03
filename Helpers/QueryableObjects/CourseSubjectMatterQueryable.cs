namespace schoolApi.Helpers.QueryableObjects;

public class CourseSubjectMatterQueryable
{
    public bool? IsActived { get; set; } = null;
    public int? WorkloadHours { get; set; } = null;
    public int? Semester { get; set; } = null;
    public bool? IsMandatory { get; set; } = null;
    public string? SortBy { get; set; } = null;
    public bool IsDescending { get; set; } = false;
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 25;
}
