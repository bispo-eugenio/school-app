namespace schoolApi.Helpers.QueryableObjects;

public class CourseSubjectMatterQueryable
{
    public bool? IsActived { get; set; } = null;
    public int? WorkloadHours { get; set; } = null;
    public int? Semester { get; set; } = null;
    public bool? IsMandatory { get; set; } = null;
}
