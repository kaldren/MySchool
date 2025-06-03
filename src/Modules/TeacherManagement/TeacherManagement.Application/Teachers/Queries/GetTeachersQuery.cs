using MediatR;
using MySchool.Modules.TeacherManagement.Domain.Teachers;

namespace MySchool.Modules.TeacherManagement.Application.Teachers.Queries;

public record GetTeachersQuery() : IRequest<IReadOnlyList<Teacher>>;

public class GetTeachersQueryHandler : IRequestHandler<GetTeachersQuery, IReadOnlyList<Teacher>>
{
    private readonly ITeacherRepository _repository;

    public GetTeachersQueryHandler(ITeacherRepository repository)
    {
        _repository = repository;
    }

    public Task<IReadOnlyList<Teacher>> Handle(GetTeachersQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetAllAsync(cancellationToken);
    }
}
