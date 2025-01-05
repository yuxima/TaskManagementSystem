namespace TaskManagement.API;

public interface IServiceBusHandler
{
    Task<bool> Send(Domain.Task task, CancellationToken cancellationToken);
}
