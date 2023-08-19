using FarmersDiary.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FarmersDiary.Infrastructure.Data.Repositories;
using FarmersDiary.Infrastructure.Data.Identity;
using FarmersDiary.Core.Services;
using FarmersDiary.Core.Contracts;

namespace FarmersDiary
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IApplicationDbRepository, ApplicationDbRepository>();
            builder.Services.AddScoped<IFarmerService, FarmerService>();
            builder.Services.AddScoped<IFarmService, FarmService>();
            builder.Services.AddScoped<IAnimalService, AnimalService>();
            builder.Services.AddScoped<ILabourService, LabourService>();
            builder.Services.AddScoped<ILandService, LandService>();
            builder.Services.AddScoped<IVehicleService, VehicleService>();
            builder.Services.AddScoped<IAdminService, AdminService>();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            using(var scope = app.Services.CreateScope())
            {
                var roleManger = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] {"User","Admin"};

                foreach (var role in roles)
                {
                    if (!await roleManger.RoleExistsAsync(role))
                        await roleManger.CreateAsync(new IdentityRole(role));
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var userManger = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                string email = "admin@admin.com";
                string password = "Admin123!";

                if (await userManger.FindByEmailAsync(email) == null)
                {
                    var user = new User();
                    user.Email = email;
                    user.UserName = email;

                    await userManger.CreateAsync(user, password);

                    await userManger.AddToRoleAsync(user, "Admin");
                }
                
            }

            app.Run();
        }
    }
}