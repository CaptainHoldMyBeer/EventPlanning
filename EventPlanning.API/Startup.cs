using Infrastructure.Bll.Core.CreateUserService;
using Infrastructure.Bll.Core.EventProviderService;
using Infrastructure.Bll.Core.LoginUserService;
using Infrastructure.Bll.Utils.EmailService;
using Infrastructure.Dal.Core.EventDalService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Model;
using Model.Models;

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
            services.AddIdentity<User, IdentityRole<int>>(p => 
              { p.Password.RequiredLength = 8; 
                p.Password.RequireNonAlphanumeric = false; 
                p.Password.RequireUppercase = false; 
                p.Password.RequireLowercase = false; 
                p.Password.RequireDigit = false; })
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IEmailService, EmailService>();
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
