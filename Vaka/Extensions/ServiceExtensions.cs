﻿using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;
using Services;
using Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Vaka.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) => services.AddDbContext<RepositoryContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureGeneral(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IServiceManager, ServiceManager>();

            services.AddSingleton<ILoggerService, LoggerService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomService, RoomService>();

            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IStoreService, StoreService>();

            services.AddScoped<IStructureRepository, StructureRepository>();
            services.AddScoped<IStructureService, StructureService>();

            services.AddScoped<IWorkOrderRepository, WorkOrderRepository>();
            services.AddScoped<IWorkOrderService, WorkOrderService>();

            services.AddScoped<IProductRoomRepository, ProductRoomRepository>();
            services.AddScoped<IProductRoomService, ProductRoomService>();

            services.AddScoped<IProductStoreRepository, ProductStoreRepository>();
            services.AddScoped<IProductStoreService, ProductStoreService>();

            services.AddScoped<ISaveStoreRepository, SaveStoreRepository>();
            services.AddScoped<ISaveStoreService, SaveStoreService>();

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", build => build.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod().WithExposedHeaders("X-Pagination"));
            });
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.Password.RequireLowercase = false;
                opt.Password.RequireDigit = true;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 6;

                opt.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<RepositoryContext>().AddDefaultTokenProviders();
        }

        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["secretKey"];

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["validIssuer"],
                    ValidAudience = jwtSettings["validAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!)),
                };
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Vaka API", Version = "v1" });
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Description = "Bearer xxTOKENxx",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                 Type = ReferenceType.SecurityScheme,
                                 Id = "Bearer"
                            },
                            Name = "Bearer"
                        },
                        new List<string>()
                    }
                });
            });
        }
    }
}
