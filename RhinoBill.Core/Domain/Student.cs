namespace RhinoBill.Core;

public class Student : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set;}
    public DateTime Birthday { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public ICollection<Application> Applications { get; set; }
    public ICollection<Course> Courses { get; set; }
}
