using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Commands;
using TaskManagement.Application.Queries;
using TaskManagement.Domain;

namespace TaskManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController(IMediator mediator, IServiceBusHandler serviceBusHandler) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Domain.Task>> Get(CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetTasksQuery(), cancellationToken);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id,CancellationToken cancellationToken)
    {
        var task =  await mediator.Send(new GetTaskByIdQuery(id), cancellationToken);

        if (task is null)
        {
            return BadRequest($"Task is not found for id: {id}");
        }

        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]Domain.Task task, CancellationToken cancellationToken)
    {
        var processedViaMessageBroker = await serviceBusHandler.Send(task, cancellationToken);
        if (!processedViaMessageBroker)
        {
            return BadRequest("Unable to process through message broker.");
        }

        return Ok(await mediator.Send(new AddTaskCommand(task), cancellationToken));
    }

    [HttpPatch]
    public async Task<IActionResult> Patch(int id, Status newStatus, CancellationToken cancellationToken)
    {
        var task = await mediator.Send(new UpdateTaskStatusCommand(id, newStatus), cancellationToken);

        if (task is null)
        {
            return BadRequest($"Task is not found for id: {id}");
        }

        return Ok(task);
    }
}
