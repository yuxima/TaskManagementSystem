using MediatR;
using TaskManagement.Application.Interfaces;

namespace TaskManagement.Application.Queries;

public class GetTasksQueryHandler(ITaskRepository taskRepository) : IRequestHandler<GetTasksQuery, IEnumerable<Domain.Task>>
{
    public async Task<IEnumerable<Domain.Task>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
    {
        return await taskRepository.GetAllAsync(cancellationToken);
    }
}
