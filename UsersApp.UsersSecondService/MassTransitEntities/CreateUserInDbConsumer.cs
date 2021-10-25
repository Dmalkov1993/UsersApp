using AutoMapper;
using MassTransit;
using System.Threading.Tasks;
using UsersApp.DAL;
using UsersApp.DAL.Entities;
using UsersApp.Infrastructure.RabbitMqDTO;

namespace UsersApp.UsersSecondService.MassTransitEntities
{
    public class CreateUserInDbConsumer 
        : IConsumer<CreateUserInDbTaskData> // Говорят, лучше исп. интерфейсы, но для упрощения, используем классы
    {
        private readonly IMapper mapper;
        private readonly UsersAppDbContext dbContext;

        public CreateUserInDbConsumer(IMapper mapper, UsersAppDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public async Task Consume(ConsumeContext<CreateUserInDbTaskData> context)
        {
            // Запись в БД
            var user = mapper.Map<User>(context.Message);

            await dbContext.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }
    }
}
