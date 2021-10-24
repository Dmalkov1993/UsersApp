using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersApp.Infrastructure.RabbitMqDTO;
using UsersApp.PostFIOFirstService.RequestPayloads;

namespace UsersApp.PostFIOFirstService.Mappings
{
    public class UserDataMapperProfile : Profile
    {
        public UserDataMapperProfile()
        {
            CreateMap<AcceptUserDataRequestPayload, CreateUserInDbTaskData>();
        }
    }
}
