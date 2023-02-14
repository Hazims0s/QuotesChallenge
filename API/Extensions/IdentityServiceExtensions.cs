using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using API.Services;
using Domain;

using Persistence;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddApplicationIdentityServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddIdentityCore<AppUser>(opt => {
                opt.User.RequireUniqueEmail =true ;
                
            }).AddEntityFrameworkStores<DataContext>();
            services.AddAuthorization();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                }
            );

            services.AddScoped<TokenService>();
            return services;
        }


    }
}