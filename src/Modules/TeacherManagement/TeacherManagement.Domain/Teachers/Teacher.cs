namespace MySchool.Modules.TeacherManagement.Domain.Teachers;

public class Teacher
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Subject { get; private set; } = string.Empty;

    private Teacher() {}

    public Teacher(Guid id, string firstName, string lastName, string subject)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Subject = subject;
    }
}
