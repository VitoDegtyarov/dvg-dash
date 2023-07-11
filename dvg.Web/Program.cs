using dvg.Data;
using dvg.Data.Repositories;
using dvg.Data.Repositories.Interfaces;
using dvg.Data.UnitOfWork;
using dvg.Mappers;
using dvg.Services;
using dvg.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace dvg.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IDesignerRepository, DesignerRepository>();
            builder.Services.AddScoped<Lazy<IDesignerRepository>>(provider =>
            {
                return new Lazy<IDesignerRepository>(() => provider.GetRequiredService<IDesignerRepository>());
            });

            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<Lazy<IClientRepository>>(provider =>
            {
                return new Lazy<IClientRepository>(() => provider.GetRequiredService<IClientRepository>());
            });

            builder.Services.AddScoped<IDesignerService, DesignerService>();
            builder.Services.AddScoped<IClientService, ClientService>();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddAutoMapper(typeof(AppMappingProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

           

            app.Run();

            

        }
    }
}