using Microsoft.EntityFrameworkCore;
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
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

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
