namespace MySchool.Modules.StudentManagement.Domain.Students;

public class Student
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateOnly BirthDate { get; private set; }

    // EF constructor
    private Student() {}

    public Student(Guid id, string firstName, string lastName, DateOnly birthDate)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }
}
