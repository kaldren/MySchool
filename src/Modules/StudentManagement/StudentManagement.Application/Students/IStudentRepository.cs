using MySchool.Modules.StudentManagement.Domain.Students;

namespace MySchool.Modules.StudentManagement.Application.Students;

public interface IStudentRepository
{
    Task AddAsync(Student student, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Student>> GetAllAsync(CancellationToken cancellationToken = default);
}
