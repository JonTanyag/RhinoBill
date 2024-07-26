namespace RhinoBill.Application;

public record CourseDto
{
    public string Code { get; set; }
    public string Title { get; set; }
    public int Credits { get; set; }
}
