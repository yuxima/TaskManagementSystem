using MediatR;
using TaskManagement.Domain;

namespace TaskManagement.Application.Commands;

public record UpdateTaskStatusCommand(Status Status) : IRequest<Domain.Task>
{
}
