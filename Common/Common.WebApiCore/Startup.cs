using System.Reflection;
using AutoMapper;
using Common.Services.Infrastructure;
using Common.WebApiCore.Middlewares;
using Common.WebApiCore.Setup;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Common.WebApiCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        protected void ConfigureDependencies(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("Default");
            DependenciesConfig.ConfigureDependencies(services, this.Configuration, connectionString);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureIdentity();
            services.ConfigureAuth(this.Configuration);
            ConfigureDependencies(services);
            services.ConfigureSwagger();
            services.ConfigureCors();
            services.AddAutoMapper(Assembly.Load("Common.Services.Infrastructure"));
            services.AddControllers(options =>
            {
                options.UseCentralRoutePrefix(new RouteAttribute("api"));
            })
            .AddFluentValidation(options =>
            {
                options.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                options.LocalizationEnabled = false;
                options.RegisterValidatorsFromAssembly(Assembly.Load("Common.DTO"));
            })
            .AddNewtonsoftJson();
            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDataBaseInitializer dataBaseInitializer)
        {
            if (dataBaseInitializer != null)
            {
                dataBaseInitializer.Initialize();
            }
            else
            {
                // TODO: add logging
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseConfiguredSwagger();

            app.UseCors("CorsPolicy");

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}