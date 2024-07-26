namespace RhinoBill.Application;

public class DeleteStudentResponse : BaseResponse
{
    public DeleteStudentResponse(bool isDeleted, string message, int statusCode)
    {
        IsDeleted = isDeleted;
        Message = message;
        StatusCode = statusCode;
    }

    public bool IsDeleted { get; set; }
}
