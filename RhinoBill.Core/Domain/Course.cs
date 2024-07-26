namespace RhinoBill.Core;

public class Course : BaseEntity
{
    public string Code { get; set; }
    public string Title { get; set; }
    public int Credits { get; set; }

    public ICollection<Application> Applications { get; set; }
}
