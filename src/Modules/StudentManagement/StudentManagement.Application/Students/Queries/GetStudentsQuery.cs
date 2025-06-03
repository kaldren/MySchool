using MediatR;
using MySchool.Modules.StudentManagement.Domain.Students;

namespace MySchool.Modules.StudentManagement.Application.Students.Queries;

public record GetStudentsQuery() : IRequest<IReadOnlyList<Student>>;

public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IReadOnlyList<Student>>
{
    private readonly IStudentRepository _repository;

    public GetStudentsQueryHandler(IStudentRepository repository)
    {
        _repository = repository;
    }

    public Task<IReadOnlyList<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetAllAsync(cancellationToken);
    }
}
