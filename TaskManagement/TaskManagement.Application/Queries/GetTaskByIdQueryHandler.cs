using MediatR;
using Task = TaskManagement.Domain.Task;

namespace TaskManagement.Application.Queries;

public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, Domain.Task?>
{
    public Task<Task?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
