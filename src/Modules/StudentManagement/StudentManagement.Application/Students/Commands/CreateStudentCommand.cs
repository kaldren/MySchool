using MediatR;
using MySchool.Modules.StudentManagement.Domain.Students;

namespace MySchool.Modules.StudentManagement.Application.Students.Commands;

public record CreateStudentCommand(string FirstName, string LastName, DateOnly BirthDate) : IRequest<Guid>;

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Guid>
{
    private readonly IStudentRepository _repository;

    public CreateStudentCommandHandler(IStudentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = new Student(Guid.NewGuid(), request.FirstName, request.LastName, request.BirthDate);
        await _repository.AddAsync(student, cancellationToken);
        return student.Id;
    }
}
