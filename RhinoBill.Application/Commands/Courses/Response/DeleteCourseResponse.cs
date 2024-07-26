namespace RhinoBill.Application;

public class DeleteCourseResponse : BaseResponse
{
    public DeleteCourseResponse(bool isDeleted, string message, int statusCode)
    {
        IsDeleted = isDeleted;
    }
    public bool IsDeleted { get; set; }
}
