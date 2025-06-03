using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using MySchool.Modules.StudentManagement.Application.Students;
using MySchool.Modules.StudentManagement.Application.Students.Commands;
using MySchool.Modules.StudentManagement.Application.Students.Queries;
using MySchool.Modules.StudentManagement.Infrastructure.Students;

namespace MySchool.Modules.StudentManagement.Api;

public static class StudentManagementModule
{
    public static IServiceCollection AddStudentManagement(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateStudentCommand).Assembly);
        services.AddDbContext<StudentDbContext>(options =>
            options.UseInMemoryDatabase("StudentManagement"));
        services.AddScoped<IStudentRepository, StudentRepository>();
        return services;
    }

    public static IEndpointRouteBuilder MapStudentManagementEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/students");

        group.MapPost("/", async (IMediator mediator, CreateStudentCommand command) =>
        {
            var id = await mediator.Send(command);
            return Results.Created($"/students/{id}", new { id });
        });

        group.MapGet("/", async (IMediator mediator) => await mediator.Send(new GetStudentsQuery()));
        return app;
    }
}
