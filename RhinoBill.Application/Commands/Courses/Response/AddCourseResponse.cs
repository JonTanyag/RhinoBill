namespace RhinoBill.Application;

public class AddCourseResponse : BaseResponse
{
    public AddCourseResponse(bool isCreated, string message, int statusCode)
    {
        IsCreated = isCreated;
        Message = message;
        StatusCode = statusCode;
    }
    public bool IsCreated { get; set; }
}
