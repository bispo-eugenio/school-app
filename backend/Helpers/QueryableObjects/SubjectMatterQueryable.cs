namespace schoolApi.Helpers.QueryableObjects;

public class SubjectMatterQueryable
{
    public string Name { get; set; } = "";
    public string Day { get; set; } = "";
    public TimeSpan? StartedAt { get; set; } = null;
    public TimeSpan? EndedAt { get; set; } = null;
    public int? TeacherId { get; set; } = null;
}
