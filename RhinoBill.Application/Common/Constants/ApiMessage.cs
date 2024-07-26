namespace RhinoBill.Application;

public class ApiMessage
{
    public const string Add_Student_LogInformation = "Studend added.";
    public const string Add_Student_LogError = "An error occurred while adding student.";

    public const string Update_Student_LogInformation = "Studend updated.";
    public const string Update_Student_LogError = "An error occurred while updating student.";

    // Delete Student
    public const string Delete_Student_LogInformation = "Student deleted.";
    public const string Delete_Student_LogError = "An error occurred while deleting student.";

    // Get Students
    public const string Get_Student_LogInformation = "Student found.";
    public const string Get_Student_LogError = "Schedule created.";
    public const string Get_Student_LogException = "An error occurred while getting student details.";

    public const string No_Record_Found = "No record/s found.";
}
