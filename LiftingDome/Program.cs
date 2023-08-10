namespace LiftingDome
{
    using LiftingDome.Data;
    using LiftingDome.Infrastructure.Extensions;
    using LiftingDome.Infrastructure.ModelBinders;
    using LiftingDome.Models;
    using LiftingDome.Services.Data.Interfaces;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using static Common.GeneralApplicationConstants;
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder
                = WebApplication.CreateBuilder(args);

            string connectionString
                = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

                        builder.Services.AddDbContext<LiftingDomeDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services
                .AddDbContext<LiftingDomeDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount =
                    builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                options.Password.RequireLowercase =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireUppercase =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequireNonAlphanumeric =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                options.Password.RequiredLength =
                    builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");

            })
              .AddRoles<IdentityRole<Guid>>()
              .AddEntityFrameworkStores<LiftingDomeDbContext>();

            builder.Services.AddApplicationServices(typeof(IWorkoutService));

            builder.Services.AddMemoryCache();

            builder.Services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LogoutPath = "/User/Login";
                cfg.AccessDeniedPath = "/Home/Error/401";
            });

            builder.Services.AddMvc().AddNToastNotifyToastr();

            builder.Services
                .AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                });

            WebApplication app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error/500");
                app.UseStatusCodePagesWithRedirects("Home/Error?statusCode={0}");

                app.UseHsts();
            }
            app.UseNToastNotify();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.OnlineUsersCheck();

            if (app.Environment.IsDevelopment())
            {
                app.SeedAdministator(DevelopmentAdminEmail);
            }

            app.UseEndpoints(config =>
            {
				config.MapControllerRoute(
					 name: "areas",
					 pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}");
                config.MapControllerRoute(
                    name: "ProtectingUrlRoute",
                    pattern: "/{controller}/{action}/{id}/{information}",
                    defaults: new { Controller = "WorkoutCategory", Action = "Details" });	
				config.MapDefaultControllerRoute();
                config.MapRazorPages();
            });

            app.Run();
        }
    }
}