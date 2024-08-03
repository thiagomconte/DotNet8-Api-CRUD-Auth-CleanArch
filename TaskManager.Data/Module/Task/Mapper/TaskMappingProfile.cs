using AutoMapper;
using TaskManager.Data.Module.Task.Entity;
using TaskManager.Domain.Module.Task.Model;

namespace TaskManager.Data.Module.Task.Mapper
{
    public class TaskMappingProfile : Profile
    {
        public TaskMappingProfile()
        {
            CreateMap<TaskModel, TaskEntity>().ReverseMap();
        }
    }
}
