using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ShoppingCarts.Shared.Core.Filters;
using ShoppingCarts.StorageRoom.Common.Interfaces.IDepots;
using ShoppingCarts.StorageRoom.Common.Interfaces.IFeatures;
using ShoppingCarts.StorageRoom.Core.Features;
using ShoppingCarts.StorageRoom.Data.Depots;
using ShoppingCarts.StorageRoom.Data.Interfaces.IRepositories;
using ShoppingCarts.StorageRoom.Data.MapperProfiles;
using ShoppingCarts.StorageRoom.Data.Mocks;
using ShoppingCarts.StorageRoom.Data.Repositories;

namespace ShoppingCarts.StorageRoom.Api
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
            #region Injections

            services.AddTransient<ICreateUserFeature, CreateUserFeature>();
            services.AddTransient<IReadUsersFeature, ReadUsersFeature>();

            services.AddTransient<ICreateUserDepot, CreateUserDepot>();
            services.AddTransient<IReadUsersDepot, ReadUsersDepot>();

            if (Configuration["mocked"].Equals("true", StringComparison.OrdinalIgnoreCase))
            {
                services.AddTransient<IUserRepository, UserRepositoryMock>();
            }
            else
            {
                services.AddTransient<IUserRepository, UserRepository>();
            }

            #endregion

            #region Filters

            services.AddControllers(options =>
            {
                options.Filters.Add<ApiLogActionFilterAsync>();
            });

            #endregion

            #region Automapper

            services.AddAutoMapper(typeof(DataMappingProfile));

            #endregion

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CoreServicesTemplate.StorageRoom.Api", Version = "v1" });
            });

            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoreServicesTemplate.StorageRoom.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
