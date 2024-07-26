namespace RhinoBill.Application;

public class AddApplicationResponse : BaseResponse
{
    public AddApplicationResponse(bool isCreated, string message, int statusCode)
    {
        IsCreated = isCreated;
        Message = message;
        StatusCode = statusCode;
    }

    public bool IsCreated { get; set; }
}
