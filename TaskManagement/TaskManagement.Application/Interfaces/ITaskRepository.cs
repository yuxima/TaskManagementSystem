namespace TaskManagement.Application.Interfaces;

public interface ITaskRepository
{
    Task AddAsync(Domain.Task task, CancellationToken cancellationToken);
    Task<IList<Domain.Task>> GetAllAsync(CancellationToken cancellationToken);
    Task<Domain.Task?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<Domain.Task?> UpdateStatusAsync(int id, Domain.Status status, 
        CancellationToken cancellationToken);
}
