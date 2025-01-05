using MediatR;
using TaskManagement.Application.Interfaces;

namespace TaskManagement.Application.Queries;

public class GetTaskByIdQueryHandler(ITaskRepository taskRepository) : IRequestHandler<GetTaskByIdQuery, Domain.Task?>
{
    public async Task<Domain.Task?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        return await taskRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}
