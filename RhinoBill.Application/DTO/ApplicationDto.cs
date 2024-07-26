namespace RhinoBill.Application;

public record ApplicationDto
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime ApplicationDate { get; set; } = DateTime.Now;
}
