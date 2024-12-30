using MediatR;
using TaskManagement.Domain;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Application.Commands;
public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, Domain.Task>
{
    public Task<Domain.Task> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new Domain.Task
        {
            Id = 1,
            Name = "To make a cake",
            Description = "Red Velvet cake for 4 people",
            Status = Status.NotStarted,
            AssignedTo = "User1"
        });
    }
}
