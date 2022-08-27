using Infrastructure.Bll.Core.CreateUserService;
using Infrastructure.Bll.Core.EventProviderService;
using Infrastructure.Bll.Core.LoginUserService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Model;
using Infrastructure.Bll.Utils;
using Infrastructure.Bll.Utils.EmailService;
using Infrastructure.Bll.Utils.UserProfileService;
using Infrastructure.Dal.Core.EventDalService;
using Model.Models;
using Microsoft.AspNetCore.Identity;

namespace EventPlanning.API
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

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IUserProfileService, UserProfileService>();
            services.AddTransient<ICreateUser, CreateUser>();
            services.AddTransient<ILoginUserService, LoginUserService>();
            services.AddTransient<IEventProvider, EventProvider>();
            services.AddTransient<IEventDal, EventDal>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
