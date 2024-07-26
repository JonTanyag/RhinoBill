namespace RhinoBill.Application;

public class UpdateApplicationResponse : BaseResponse
{
public UpdateApplicationResponse(bool isUpdated, string message, int statusCode)
    {
        IsUpdated = isUpdated;
        Message = message;
        StatusCode = statusCode;
    }

    public bool IsUpdated { get; set; }
}
