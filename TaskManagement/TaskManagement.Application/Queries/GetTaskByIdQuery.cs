using MediatR;

namespace TaskManagement.Application.Queries;

public class GetTaskByIdQuery : IRequest<Domain.Task?>
{
}
