using AppDisney.DataAccess;
using AppDisney.Models;
using AppDisney.Repositories;
using AppDisney.Repositories.Implements;
using AppDisney.Services;
using AppDisney.Services.Implements;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace AppDisney
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

            services.AddMvcCore()
                .AddAuthorization();

            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new OpenApiInfo { Title = "Pre-Aceleracion Francisco Casabianca", Version = "v1" });
                o.AddSecurityDefinition("Bearer",
                new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                o.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                 Id="Bearer"
                            }
                        },
                        new List<string>()
                    }
                });
            });

            services.AddControllers();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<UserDBContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(Options =>
            {
                Options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
                Options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                Options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "https://localhost:44323/",
                    ValidIssuer = "https://localhost:44323/",
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JWTsecretkey"))
                };
            });

            services.AddEntityFrameworkSqlServer();
            services.AddDbContextPool<AppDBContext>((services, options) =>
            {
            options.UseSqlServer(Configuration.GetConnectionString("AppConnection"));
            options.UseInternalServiceProvider(services);
            });            

            services.AddDbContext<UserDBContext>((services, options) =>
            {
                options.UseInternalServiceProvider(services);
                options.UseSqlServer(Configuration.GetConnectionString("UserConnection"));
            });

            services.AddScoped<IMovieRepository, MovieOrSerieRepository>();
            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();

            services.AddScoped<ICharacterService, CharacterService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IMovieService, MovieService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseSwaggerUI();

            app.UseSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            AppDBInitializer.Seed(app);
            
        }
    }
}
