using MediatR;
using TaskManagement.Domain;

namespace TaskManagement.Application.Commands;

public record UpdateTaskStatusCommand(int Id, Status NewStatus) : IRequest<Domain.Task?>
{
}
