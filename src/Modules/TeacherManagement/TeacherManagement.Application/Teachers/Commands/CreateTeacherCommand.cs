using MediatR;
using MySchool.Modules.TeacherManagement.Domain.Teachers;

namespace MySchool.Modules.TeacherManagement.Application.Teachers.Commands;

public record CreateTeacherCommand(string FirstName, string LastName, string Subject) : IRequest<Guid>;

public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, Guid>
{
    private readonly ITeacherRepository _repository;

    public CreateTeacherCommandHandler(ITeacherRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
    {
        var teacher = new Teacher(Guid.NewGuid(), request.FirstName, request.LastName, request.Subject);
        await _repository.AddAsync(teacher, cancellationToken);
        return teacher.Id;
    }
}
