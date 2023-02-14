using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Authers.Commands;
using Application.Authers.Queries;
using Application.Core;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<DataContext>(opt =>
            {
               opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddMediatR(typeof(GetListAuthers.Handler));
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<AddAuther>();
            return services ;
        }
    }
}