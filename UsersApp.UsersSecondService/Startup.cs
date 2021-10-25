using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using UsersApp.DAL;
using UsersApp.Infrastructure.AutomapperProfiles;
using UsersApp.UsersSecondService.MassTransitEntities;

namespace UsersApp.UsersSecondService
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Сервис №2",
                    Version = "v1",
                    Description = "Служит для записи в БД данных пользователя, пришедших из шины RabbitMQ." +
                    "Также можно связать пользователя и организацию, а также получить пагинированные данные о пользователях.",
                });
            });

            services.AddDbContext<UsersAppDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("UsersAppDbContext");
                options.UseNpgsql(connectionString, assembly => assembly.MigrationsAssembly("UsersApp.DAL"));
            });

            // Настройка кролика - экстеншен не подошел, т.к. нам надо зарегать консьюмера.
            // Можно было передать массив типов консьюмеров, как вариант.
            services.AddMassTransit(configurator =>
            {
                configurator.UsingRabbitMq((context, factoryConfigurator) =>
                {
                    var rabbitMqSection = configuration.GetSection("RabbitMQ");
                    factoryConfigurator.Host(new Uri(rabbitMqSection.GetValue<string>("Host")),
                        hostConfigurator =>
                        {
                            hostConfigurator.Username(rabbitMqSection.GetValue("Username", "guest"));
                            hostConfigurator.Password(rabbitMqSection.GetValue("Password", "guest"));
                        });
                    factoryConfigurator.ReceiveEndpoint("CreateUserInDbQueue",
                        endpointConfigurator => endpointConfigurator.Consumer<CreateUserInDbConsumer>(context));
                    factoryConfigurator.ConfigureEndpoints(context);
                });
            });
            services.AddMassTransitHostedService();

            /*
            var rabbitMqSection = Configuration.GetSection("RabbitMQ");
            services.AddDefaultMassTransit(
                host: rabbitMqSection.GetValue<string>("Host"),
                username: rabbitMqSection.GetValue("Username", "guest"),
                password: rabbitMqSection.GetValue("Username", "guest"));
            */

            // Nuget пакет - MediatR.Extensions.Microsoft.DependencyInjection
            services.AddMediatR(typeof(Startup));

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserDataMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<UsersAppDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSerilogRequestLogging();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SecondService");

                // To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
