namespace RhinoBill.Core;

public class Application : BaseEntity
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime ApplicationDate { get; set; }

    public Student Students { get; set; }
    public Course Courses { get; set; }
}
