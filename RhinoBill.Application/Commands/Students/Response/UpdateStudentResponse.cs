namespace RhinoBill.Application;

public class UpdateStudentResponse : BaseResponse
{
    public UpdateStudentResponse(bool isUpdated, string message, int statusCode)
    {
        IsUpdated = isUpdated;
        Message = message;
        StatusCode = statusCode;
    }
    public bool IsUpdated { get; set; }
}
