using MassTransit;
using System.Threading.Tasks;
using UsersApp.Infrastructure.RabbitMqDTO;

namespace UsersApp.UsersSecondService.MassTransitEntities
{
    public class CreateUserInDbConsumer 
        : IConsumer<CreateUserInDbTaskData> // Говорят, лучше исп. интерфейсы, но для упрощения, используем классы
    {
        public Task Consume(ConsumeContext<CreateUserInDbTaskData> context)
        {
            // Запись в БД
            return Task.CompletedTask;
        }
    }
}
