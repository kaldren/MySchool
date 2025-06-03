using Microsoft.EntityFrameworkCore;
using MySchool.Modules.TeacherManagement.Application.Teachers;
using MySchool.Modules.TeacherManagement.Domain.Teachers;

namespace MySchool.Modules.TeacherManagement.Infrastructure.Teachers;

public class TeacherRepository : ITeacherRepository
{
    private readonly TeacherDbContext _dbContext;

    public TeacherRepository(TeacherDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Teacher teacher, CancellationToken cancellationToken = default)
    {
        _dbContext.Teachers.Add(teacher);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Teacher>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Teachers.AsNoTracking().ToListAsync(cancellationToken);
    }
}
