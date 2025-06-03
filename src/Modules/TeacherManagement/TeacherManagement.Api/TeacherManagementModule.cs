using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using MySchool.Modules.TeacherManagement.Application.Teachers;
using MySchool.Modules.TeacherManagement.Application.Teachers.Commands;
using MySchool.Modules.TeacherManagement.Application.Teachers.Queries;
using MySchool.Modules.TeacherManagement.Infrastructure.Teachers;

namespace MySchool.Modules.TeacherManagement.Api;

public static class TeacherManagementModule
{
    public static IServiceCollection AddTeacherManagement(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateTeacherCommand).Assembly);
        services.AddDbContext<TeacherDbContext>(options =>
            options.UseInMemoryDatabase("TeacherManagement"));
        services.AddScoped<ITeacherRepository, TeacherRepository>();
        return services;
    }

    public static IEndpointRouteBuilder MapTeacherManagementEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/teachers");

        group.MapPost("/", async (IMediator mediator, CreateTeacherCommand command) =>
        {
            var id = await mediator.Send(command);
            return Results.Created($"/teachers/{id}", new { id });
        });

        group.MapGet("/", async (IMediator mediator) => await mediator.Send(new GetTeachersQuery()));
        return app;
    }
}
