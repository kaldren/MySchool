using Microsoft.EntityFrameworkCore;
using MySchool.Modules.StudentManagement.Domain.Students;

namespace MySchool.Modules.StudentManagement.Infrastructure.Students;

public class StudentDbContext : DbContext
{
    public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

    public DbSet<Student> Students => Set<Student>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("students");
        modelBuilder.Entity<Student>().HasKey(s => s.Id);
        base.OnModelCreating(modelBuilder);
    }
}
