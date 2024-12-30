using MediatR;

namespace TaskManagement.Application.Commands;

public record AddTaskCommand(Domain.Task Task) : IRequest<Domain.Task>
{
}
