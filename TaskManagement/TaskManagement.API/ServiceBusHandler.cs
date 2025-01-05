using MassTransit;
using System.Text.Json;

namespace TaskManagement.API;

public class ServiceBusHandler(IRequestClient<TaskMessageRequest> client) : IConsumer<TaskMessageRequest>, IServiceBusHandler
{
    private const int SendTimeoutInSeconds = 10;

    public async Task<bool> Send(Domain.Task task, CancellationToken cancellationToken)
    {
        var timeout = TimeSpan.FromSeconds(SendTimeoutInSeconds);
        using var source = new CancellationTokenSource(timeout);

        var serializedTask = JsonSerializer.Serialize(task);

        var response = await client.GetResponse<SendMessageResponse>(new TaskMessageRequest{JsonString = serializedTask}, source.Token);
        return response.Message.IsSucceeded;
    }

    public async Task Consume(ConsumeContext<TaskMessageRequest> context)
    {
        var response = new SendMessageResponse
        {
            IsSucceeded = true
        };
        try
        {
            var deserializedTask = JsonSerializer.Deserialize<Domain.Task>(context.Message.JsonString);
        }
        catch (Exception ex)
        {
            response.IsSucceeded = false;
            response.ExceptionMessage = ex.Message;
        }
        finally
        {
            await context.RespondAsync(response);
        }
    }
}

public class TaskMessageRequest
{
    public string JsonString { get; set; } = string.Empty;
}

public class SendMessageResponse
{
    public bool IsSucceeded { get; set; }

    public string? ExceptionMessage { get; set; }
}
