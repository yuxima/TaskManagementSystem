using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Interfaces;

namespace TaskManagement.Infrastructure.Repositories;

public class TaskRepository(TaskManagementDbContext dbContext) : ITaskRepository
{
    public async Task AddAsync(Domain.Task task, CancellationToken cancellationToken)
    {
        await dbContext.Tasks.AddAsync(task, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<Domain.Task>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await dbContext.Tasks
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Domain.Task?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await dbContext.Tasks
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<Domain.Task?> UpdateStatusAsync(int id, Domain.Status status, CancellationToken cancellationToken)
    {
        var entity = dbContext.Tasks.FirstOrDefault(item => item.Id == id);

        if (entity != null)
        {
            entity.Status = status;
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        return entity;
    }
}
