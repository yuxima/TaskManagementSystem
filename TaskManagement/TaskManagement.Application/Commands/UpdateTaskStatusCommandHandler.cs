using MediatR;
using TaskManagement.Application.Interfaces;
using Task = TaskManagement.Domain.Task;

namespace TaskManagement.Application.Commands;

public class UpdateTaskStatusCommandHandler(ITaskRepository taskRepository) 
    : IRequestHandler<UpdateTaskStatusCommand, Domain.Task?>
{
    public async Task<Task?> Handle(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
    {
        return await taskRepository.UpdateStatusAsync(request.Id, request.NewStatus, cancellationToken);
    }
}
