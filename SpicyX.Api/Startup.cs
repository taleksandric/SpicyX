using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using AutoMapper;
using SpicyX.Api.Core;
using SpicyX.DataAccess;
using SpicyX.Implementation.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpicyX.Application;
using SpicyX.Implementation.Commands;
using SpicyX.Implementation.Validations;
using SpicyX.Implementation.Email;
using SpicyX.Application.Email;
using SpicyX.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SpicyX.Implementation.Logger;

namespace SpicyX.Api
{
    public class Startup
    {
        private object appSettings;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = new AppSettings();

            Configuration.Bind(appSettings);

            services.AddControllers();
            services.AddTransient<UseCaseExecutor>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SpicyX.Api", Version = "v1" });
            });
            services.AddDbContext<SpicyXContext>();
            services.AddTransient<MealQuery>();
            services.AddTransient<TypeQuery>();
            services.AddTransient<InsertMeal>();
            services.AddTransient<MealDelete>();
            services.AddTransient<MealInsertValidation>();
            services.AddTransient<MealUpdate>();
            services.AddTransient<MealUpdateValidator>();
            services.AddTransient<InsertType>();
            services.AddTransient<TypeInsertValidation>();
            services.AddTransient<TypeUpdate>();
            services.AddTransient<TypeUpdateValidation>();
            services.AddTransient<DeleteType>();
            services.AddTransient<OrderInsert>();
            services.AddTransient<OrderValidation>();
            services.AddTransient<DeleteOrder>();
            services.AddTransient<UserQuery>();
            services.AddTransient<UserUpdate>();
            services.AddTransient<UserUpdateValidation>();
            services.AddTransient<UserDelete>();
            services.AddTransient<OrderQuery>();
            services.AddTransient<UseCaseQuery>();
            services.AddTransient<ReservationInsert>();
            services.AddTransient<ReservationInsertValidation>();
            services.AddTransient<DeleteReservation>();
            services.AddTransient<ReservationQuery>();

            services.AddTransient<UserInsert>();
            services.AddTransient<UserInsertValidation>();

            services.AddAutoMapper(typeof(MealQuery).Assembly);
            services.AddAutoMapper(typeof(TypeQuery).Assembly);

            services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();
            services.AddHttpContextAccessor();

            services.AddTransient<IEmailSender>(x => new SmtpEmailSender(appSettings.EmailFrom, appSettings.EmailPassword));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "SpicyX", Version = "v2" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
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

            services.AddTransient<IApplicationUser>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var user = accessor.HttpContext.User;

                if (user.FindFirst("UserData") == null)
                {
                    return new UnregisteredUser();
                }

                var userString = user.FindFirst("UserData").Value;

                var userJwt = JsonConvert.DeserializeObject<JwtUser>(userString);

                return userJwt;
            });

            services.AddTransient<JwtManager>(x =>
            {
                var context = x.GetService<SpicyXContext>();

                return new JwtManager(context, appSettings.JwtIssuer, appSettings.JwtSecretKey);
            });
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = appSettings.JwtIssuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JwtSecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }   

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }

            app.UseCors(x =>
            {
                x.AllowAnyOrigin();
                x.AllowAnyMethod();
                x.AllowAnyHeader();
            });
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Swagger");
            });
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseMiddleware<ExceptionHandler>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
