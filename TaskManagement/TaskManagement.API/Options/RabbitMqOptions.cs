using System.ComponentModel.DataAnnotations;

namespace TaskManagement.API.Options;

public class RabbitMqOptions
{
    public const string SectionName = "RabbitMq";

    [Required]
    public string Host { get; set; } = string.Empty;

    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    public string QueueName { get; set; } = string.Empty;
}
