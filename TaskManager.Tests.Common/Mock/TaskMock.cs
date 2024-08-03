using TaskManager.Data.Module.Task.Entity;
using TaskManager.Domain.Module.Task.Model;

namespace TaskManager.Integration.Tests.Data.UserTask
{
    public class TaskMock
    {
        static public TaskEntity TaskEntity1 { get; set; } = new TaskEntity { Id = 1, Title = "Title1", Description = "Description1" };
        static public TaskEntity TaskEntity2 { get; set; } = new TaskEntity { Id = 2, Title = "Title2", Description = "Description2" };
        static public TaskEntity TaskEntity3 { get; set; } = new TaskEntity { Id = 3, Title = "Title3", Description = "Description3", UserId = 3 };

        static public TaskModel Task1 { get; set; } = new TaskModel { Id = 1, Title = "Title1", Description = "Description1" };
        static public TaskModel Task2 { get; set; } = new TaskModel { Id = 2, Title = "Title2", Description = "Description2" };
        static public TaskModel Task3 { get; set; } = new TaskModel { Id = 3, Title = "Title3", Description = "Description3", UserId = 3 };
    }
}
