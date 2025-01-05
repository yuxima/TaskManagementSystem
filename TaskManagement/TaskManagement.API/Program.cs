using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaskManagement.API;
using TaskManagement.API.Options;
using TaskManagement.Application.Extensions;
using TaskManagement.Infrastructure;
using TaskManagement.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers();

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddScoped<IServiceBusHandler, ServiceBusHandler>()
.AddInfrastructure(builder.Configuration)
.AddApplication();

var rabbitMqOptionsOptions = builder.Configuration
    .GetRequiredSection(RabbitMqOptions.SectionName)
    .Get<RabbitMqOptions>() ?? new RabbitMqOptions();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ServiceBusHandler>()
        .Endpoint(e =>
        {
            e.Name = rabbitMqOptionsOptions.QueueName;
        });

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri(rabbitMqOptionsOptions.Host), h =>
        {
            h.Username(rabbitMqOptionsOptions.Username);
            h.Password(rabbitMqOptionsOptions.Password);
        });

        cfg.ReceiveEndpoint(rabbitMqOptionsOptions.QueueName, e =>
        {
            e.ConfigureConsumer<ServiceBusHandler>(context);
        });
    });

    x.AddRequestClient<SendMessageResponse>(new Uri($"exchange:{rabbitMqOptionsOptions.QueueName}"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.


using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<TaskManagementDbContext>();
    await dbContext.Database.MigrateAsync();
}

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
app.UseAuthorization();

app.MapControllers();

app.Run();
