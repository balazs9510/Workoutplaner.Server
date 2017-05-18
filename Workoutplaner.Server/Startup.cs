using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Workoutplaner.Server.Context;
using Workoutplaner.Server.Services;
using Workoutplaner.Server.Middlewares;
using Microsoft.AspNetCore.Http;
using Workoutplaner.Server.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace Workoutplaner.Server
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DataAccessMySqlProvider");
            services.AddDbContext<WorkoutContext>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IExerciseService, ExerciseService>();
            services.AddTransient<IDailyWorkoutService, DailyWorkoutService>();
            services.AddTransient<IWeeklyWorkoutService, WeeklyWorkoutService>();
            services.AddTransient<IMonthlyWorkoutService, MonthlyWorkoutService>();
            

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<WorkoutContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;

                // Cookie settings
                options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(150);
                options.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
                options.Cookies.ApplicationCookie.LogoutPath = "/Account/LogOut";

                // User settings
                options.User.RequireUniqueEmail = true;
            });
            
            services.AddMvc();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory, WorkoutContext context)
        {
            loggerFactory.AddConsole();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseWhen(
                ctx => ctx.Request.Path.HasValue && ctx.Request.Path.StartsWithSegments(new PathString("/api")),
                b => b.UseMiddleware<ApiExceptionHandlerMiddleware>());

            app.UseStaticFiles();

            app.UseIdentity();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });            context.Seed();
        }
    }
}
