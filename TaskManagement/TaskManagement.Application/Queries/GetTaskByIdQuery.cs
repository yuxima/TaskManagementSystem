using MediatR;

namespace TaskManagement.Application.Queries;

public record GetTaskByIdQuery(int Id) : IRequest<Domain.Task?>
{
}
