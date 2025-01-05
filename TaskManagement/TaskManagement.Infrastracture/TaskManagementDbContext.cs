using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace TaskManagement.Infrastructure;

public class TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options)
    : DbContext(options)
{
    public DbSet<Domain.Task> Tasks { get; set; }

}
