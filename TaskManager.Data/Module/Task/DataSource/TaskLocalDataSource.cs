using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Module.Exceptions;
using TaskManager.Data.Module.Database;
using TaskManager.Data.Module.Task.Entity;

namespace TaskManager.Data.Module.Task.DataSource;

public class TaskLocalDataSource : ITaskLocalDataSource
{
    private readonly TaskManagerDbContext _dbContext;

    public TaskLocalDataSource(TaskManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<TaskEntity>> GetAllAsync()
    {
        return await _dbContext.Task.Include(task => task.User).AsNoTracking().ToListAsync();
    }

    public async Task<TaskEntity> GetByIdAsync(int id)
    {
        return await _dbContext.Task.FindAsync(id) ?? throw new EntityNotFoundException("Tarefa não encontrada");
    }

    public async Task<TaskEntity> AddTaskAsync(TaskEntity task)
    {
        _dbContext.Task.Add(task);
        await _dbContext.SaveChangesAsync();
        return task;
    }

    public async Task<TaskEntity> AssignUserAsync(int userId, int taskId)
    {
        var task = await _dbContext.Task.FindAsync(taskId) ?? throw new EntityNotFoundException("Tarefa não encontrada");
        task.UserId = userId;
        await _dbContext.SaveChangesAsync();
        var updatedTask = await _dbContext.Task
                                      .Include(t => t.User)
                                      .AsNoTracking()
                                      .FirstOrDefaultAsync(t => t.Id == taskId);

        // Retorna a tarefa atualizada
        return updatedTask ?? throw new EntityNotFoundException("Tarefa não encontrada após atualização");
    }
}
