namespace RhinoBill.Application;

public class AddStudentResponse : BaseResponse
{
    public AddStudentResponse(bool isCreated, string message, int statusCode)
    {
        IsCreated = isCreated;
        Message = message;
        StatusCode = statusCode;
    }
    public bool IsCreated { get; set; }
}
