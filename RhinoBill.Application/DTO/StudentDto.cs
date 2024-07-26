namespace RhinoBill.Application;

public record StudentDto
{
    public int Id { get; set;}
    public string FirstName { get; set; }
    public string LastName { get; set;}
    public DateTime Birthday { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
