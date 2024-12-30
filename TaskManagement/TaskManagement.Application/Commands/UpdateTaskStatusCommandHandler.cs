using MediatR;
using Task = TaskManagement.Domain.Task;

namespace TaskManagement.Application.Commands;

public class UpdateTaskStatusCommandHandler : IRequestHandler<UpdateTaskStatusCommand, Domain.Task>
{
    public Task<Task> Handle(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
