namespace RhinoBill.Application;

public record CourseDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Title { get; set; }
    public int Credits { get; set; }
}
