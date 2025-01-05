using MediatR;
using TaskManagement.Domain;

namespace TaskManagement.Application.Commands;

public record UpdateTaskStatusCommand(int Id, Status Status) : IRequest<Domain.Task?>
{
}
