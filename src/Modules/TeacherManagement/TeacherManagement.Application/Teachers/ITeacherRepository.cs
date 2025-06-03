using MySchool.Modules.TeacherManagement.Domain.Teachers;

namespace MySchool.Modules.TeacherManagement.Application.Teachers;

public interface ITeacherRepository
{
    Task AddAsync(Teacher teacher, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Teacher>> GetAllAsync(CancellationToken cancellationToken = default);
}
