namespace schoolApi.Helpers.QueryableObjects;

public class ClassroomSubjectMatterQueryable
{
    public string? Day { get; set; } = null;
    public TimeSpan? StartedAt { get; set; } = null;
    public TimeSpan? EndedAt { get; set; } = null;
    public string? SortBy { get; set; } = null;
    public bool IsDescending { get; set; } = false;
}
