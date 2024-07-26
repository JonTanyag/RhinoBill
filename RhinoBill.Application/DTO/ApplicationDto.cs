namespace RhinoBill.Application;

public record ApplicationDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public string  StudentName { get; set; }
    public string Course { get; set; }
    public DateTime ApplicationDate { get; set; } = DateTime.Now;
}
