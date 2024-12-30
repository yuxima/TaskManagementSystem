using MediatR;

namespace TaskManagement.Application.Queries;

public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, IEnumerable<Task>>
{
    public Task<IEnumerable<Task>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
