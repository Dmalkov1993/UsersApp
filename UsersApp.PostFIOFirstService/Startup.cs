using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using UsersApp.Infrastructure.Extensions;
using UsersApp.PostFIOFirstService.RequestPayloads;
using UsersApp.PostFIOFirstService.Validators;

namespace UsersApp.PostFIOFirstService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Сервис №1",
                    Version = "v1",
                    Description = "Служит для приема полезной нагрузки с данными пользователя (имя, фамилия, отчество, номер, email).",
                });
            });

            var rabbitMqSection = Configuration.GetSection("RabbitMQ");
            services.AddDefaultMassTransit(
                host: rabbitMqSection.GetValue<string>("Host"),
                username: rabbitMqSection.GetValue("Username", "guest"),
                password: rabbitMqSection.GetValue("Username", "guest"));

            // Nuget пакет - MediatR.Extensions.Microsoft.DependencyInjection
            services.AddMediatR(typeof(Startup));

            // Валидация
            services.AddTransient<IValidator<AcceptUserDataRequestPayload>, AcceptUserDataValidator>();
            services.AddTransient<IValidator<string>, EmailAddressValidator>();
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FirstService");

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
