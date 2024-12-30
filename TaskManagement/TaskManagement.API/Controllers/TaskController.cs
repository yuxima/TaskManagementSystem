using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Commands;
using TaskManagement.Application.Queries;
using TaskManagement.Domain;

namespace TaskManagement.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController(IMediator mediator, ILogger<TaskController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Domain.Task>> Get(CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetTasksQuery(), cancellationToken);
    }

    [HttpPost]
    public async Task<Domain.Task?> Post(Domain.Task task, CancellationToken cancellationToken)
    {
        return await mediator.Send(new AddTaskCommand(task), cancellationToken);
    }

    [HttpPatch]
    public async Task<Domain.Task?> Post(Status taskStatus, CancellationToken cancellationToken)
    {
        return await mediator.Send(new UpdateTaskStatusCommand(taskStatus), cancellationToken);
    }
}
