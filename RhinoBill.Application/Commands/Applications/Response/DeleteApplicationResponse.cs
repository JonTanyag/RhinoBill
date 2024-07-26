namespace RhinoBill.Application;

public class DeleteApplicationResponse : BaseResponse
{
public DeleteApplicationResponse(bool isDeleted, string message, int statusCode)
    {
        IsDeleted = isDeleted;
        Message = message;
        StatusCode = statusCode;
    }

    public bool IsDeleted { get; set; }
}
