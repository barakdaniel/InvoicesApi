using Invoices.Api.Middlewares;
using Invoices.Business;
using Invoices.Data;
using Invoices.Model.AppSettings;
using Microsoft.OpenApi.Models;

namespace Invoices.Api
{
    public class Startup
    {
        public Startup(IHostEnvironment i_env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(i_env.ContentRootPath)
            .AddJsonFile("appsettings.json", false, true)
            .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //init AppSettings service using appsettings.json
            AppSettings appSettings = new();
            Configuration.GetSection(nameof(AppSettings))
                             .Bind(appSettings);

            services.AddSingleton(appSettings);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<FactoryService>();

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Invoices API",
                    Description = "Requests must contain creds",
                    Contact = new OpenApiContact() { Name = "Barak", Email = "barakdaniel22@gmail.com" }
                });

                c.AddSecurityDefinition("ClientId", new OpenApiSecurityScheme()
                {
                    Description = "ClientId",
                    Name = "ClientId",
                    In = ParameterLocation.Header
                });

                c.AddSecurityDefinition("ClientSecret", new OpenApiSecurityScheme()
                {
                    Description = "ClientSecret",
                    Name = "ClientSecret",
                    In = ParameterLocation.Header
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference{
                                Id = "ClientId",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference{
                                        Id = "ClientSecret",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
            });

            services.AddAuthorization();

            services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

            if (Configuration["env"] == "dev")
            {
                dbdef.ConnectionString = Configuration["Db:LOCAL"];
            }
            else
            {
                dbdef.ConnectionString = Configuration["Db:PROD"];
            }
        }


        public void Configure(IApplicationBuilder app, IHostApplicationLifetime lifetime)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseCors("corsapp");
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMvc();
        }
    }
}