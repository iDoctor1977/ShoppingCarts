using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoppingCarts.Console.Common.Interfaces.IFeatures;
using ShoppingCarts.Console.Core.Features;
using ShoppingCarts.Console.Services;
using ShoppingCarts.Console.Web.MapperProfiles;
using ShoppingCarts.Console.Web.Models;
using ShoppingCarts.Console.Web.Presenters;
using ShoppingCarts.Console.Web.Receivers;
using ShoppingCarts.Shared.Core.Interfaces.IConsolidators;
using ShoppingCarts.Shared.Core.Interfaces.ICustomMappers;
using ShoppingCarts.Shared.Core.Interfaces.IServices;
using ShoppingCarts.Shared.Core.Mappers;
using ShoppingCarts.Shared.Core.Models;
using ShoppingCarts.Shared.Core.Receivers;

namespace ShoppingCarts.Console.Web
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
            #region Injection

            services.AddTransient<ICreateUserFeature, CreateUserFeature>();
            services.AddTransient<IReadUsersFeature, ReadUsersFeature>();

            services.AddTransient<IStorageRoomService, StorageRoomService>();

            #endregion

            #region Consolidator

            services.AddTransient<ICustomMapper, CustomMapper>();

            services.AddTransient(typeof(IConsolidators<,>), typeof(DefaultReceiver<,>));
            services.AddTransient(typeof(IConsolidators<UserViewModel, UserApiModel>), typeof(CreateUserCustomReceiver));
            services.AddTransient(typeof(IConsolidators<UserApiModel, UserViewModel>), typeof(ReadUserCustomPresenter));
            services.AddTransient(typeof(IConsolidators<UsersApiModel, UsersViewModel>), typeof(ReadUsersCustomPresenter));

            #endregion

            #region Automapper

            services.AddAutoMapper(typeof(WebMappingProfile));

            #endregion

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
