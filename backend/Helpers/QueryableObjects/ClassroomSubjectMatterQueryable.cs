namespace schoolApi.Helpers.QueryableObjects;

public class ClassroomSubjectMatterQueryable
{
    public string? Day { get; set; } = null;
    public TimeSpan? StartedAt { get; set; } = null;
    public TimeSpan? EndedAt { get; set; } = null;
}
