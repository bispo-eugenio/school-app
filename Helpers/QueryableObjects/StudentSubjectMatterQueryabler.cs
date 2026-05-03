namespace schoolApi.Helpers.QueryableObjects;

public class StudentSubjectMatterQueryable
{
    public decimal? FirstGrade { get; set; } = null;
    public decimal? SecondGrade { get; set; } = null;
    public decimal? GradeTotal { get; set; } = null;
    public string? SortBy { get; set; } = null;
    public bool IsDescending { get; set; } = false;
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 25;
}
