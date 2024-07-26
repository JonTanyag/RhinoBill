namespace RhinoBill.Application;

public class UpdateCourseResponse : BaseResponse
{
    public UpdateCourseResponse(bool isUpdated, string message, int statusCode)
    {
        IsUpdated = isUpdated;
    }

    public bool IsUpdated { get; set; }
}
