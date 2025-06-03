using Microsoft.EntityFrameworkCore;
using MySchool.Modules.StudentManagement.Application.Students;
using MySchool.Modules.StudentManagement.Domain.Students;

namespace MySchool.Modules.StudentManagement.Infrastructure.Students;

public class StudentRepository : IStudentRepository
{
    private readonly StudentDbContext _dbContext;

    public StudentRepository(StudentDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Student student, CancellationToken cancellationToken = default)
    {
        _dbContext.Students.Add(student);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Student>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Students.AsNoTracking().ToListAsync(cancellationToken);
    }
}
