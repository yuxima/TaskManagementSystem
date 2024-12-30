using MediatR;

namespace TaskManagement.Application.Queries;

public class GetTasksQuery : IRequest<IEnumerable<Domain.Task>>
{
}
