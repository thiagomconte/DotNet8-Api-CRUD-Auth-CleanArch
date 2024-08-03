using AutoMapper;
using TaskManager.Data.Module.User.Entity;
using TaskManager.Domain.Module.User.Model;

namespace TaskManager.Data.Module.User.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserModel, UserEntity>().ReverseMap();
        }
    }
}
