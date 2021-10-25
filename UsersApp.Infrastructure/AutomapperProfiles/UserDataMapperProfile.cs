using AutoMapper;
using UsersApp.DAL.Entities;
using UsersApp.Infrastructure.RabbitMqDTO;
using UsersApp.Infrastructure.RequestPayloads;

namespace UsersApp.Infrastructure.AutomapperProfiles
{
    public class UserDataMapperProfile : Profile
    {
        public UserDataMapperProfile()
        {
            CreateMap<AcceptUserDataRequestPayload, CreateUserInDbTaskData>();
            CreateMap<CreateUserInDbTaskData, User>();
        }
    }
}
