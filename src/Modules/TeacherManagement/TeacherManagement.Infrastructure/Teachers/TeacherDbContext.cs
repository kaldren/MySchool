using Microsoft.EntityFrameworkCore;
using MySchool.Modules.TeacherManagement.Domain.Teachers;

namespace MySchool.Modules.TeacherManagement.Infrastructure.Teachers;

public class TeacherDbContext : DbContext
{
    public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options) { }

    public DbSet<Teacher> Teachers => Set<Teacher>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("teachers");
        modelBuilder.Entity<Teacher>().HasKey(t => t.Id);
        base.OnModelCreating(modelBuilder);
    }
}
