using MediatR;
using TaskManagement.Application.Interfaces;

namespace TaskManagement.Application.Commands;
public class AddTaskCommandHandler(ITaskRepository taskRepository)
    : IRequestHandler<AddTaskCommand, Domain.Task>
{
    public async Task<Domain.Task> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        await taskRepository.AddAsync(request.Task, cancellationToken);
        return request.Task;
    }
}
