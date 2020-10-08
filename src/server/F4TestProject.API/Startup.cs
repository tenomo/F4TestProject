using AutoMapper;
using F4TestProject.API.Middleware;
using F4TestProject.API.Models;
using F4TestProject.API.SwaggerExamples;
using F4TestProject.Domain.Data;
using F4TestProject.Domain.Models;
using F4TestProject.Domain.Services;
using F4TestProject.Domain.Services.Users;
using F4TestProject.Infrastructure;
using F4TestProject.Infrastructure.JsonConverters;
using F4TestProject.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace F4TestProject.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateFormatConverter());
                options.JsonSerializerOptions.Converters.Add(new TimeFormatConverter());
            }).AddMvcOptions(options =>
            {
                options.Filters.Add(new ErrorsFilter());
            });

            services.AddSwaggerExamples();
            services.AddSwaggerExamplesFromAssemblyOf<ActionItemRequestExample>();

            services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("actionShop"));
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddScoped<IUserRepository, UsersRepository>();
            services.AddScoped<IActionItemRepository, ActionItemRepository>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IActionItemsService, ActionItemsService>();

            services.AddAutoMapper(mapperConfig =>
            {
                mapperConfig.CreateMap<ActionItemRequest, ActionItem>();
            });


            //TODO move to sm. extenstion
            services.AddSwaggerGen(options =>
        {
            options.ExampleFilters();
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] [token]",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
            });
        });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseMiddleware<JwtMiddleware>();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

            });
        }
    }
}
