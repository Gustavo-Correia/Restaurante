using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Service;

namespace RestauranteWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IGarcomService, GarcomService>();
            builder.Services.AddTransient<IItemcardapioService, ItemcardapioService>();
            builder.Services.AddTransient<IRestauranteService, RestauranteService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddDbContext<RestauranteContext>(
                options => options.UseMySQL(builder.Configuration.GetConnectionString("RestauranteDatabase")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
           
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
