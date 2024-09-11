using Company.G01.BLL.interfaces;
using Company.G01.BLL.Repositories;
using Company.G01.DAL.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Company.G01.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            
            // Add services to the container.
            builder.Services.AddControllersWithViews();


            //-------------------------------------------------------------

            //builder.Services.AddScoped<AppDbContext>(); // Allow Dependancy Ingecation For AppDbContext
    
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            }); // Allow Dependancy Ingecation For AppDbContext --> AppDbContext ل Create يعمل CLR هنا عملت حقن عشان اخلي ال

            //-------------------------------------------------------------

            builder.Services.AddScoped<IDepartmentRepository , DepartmentRepository>();//Allow Dependancy Ingecation For DepartmentRepository

            //-------------------------------------------------------------

            var app = builder.Build();

            //-------------------------------------------------------------

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //-------------------------------------------------------------

            app.UseStaticFiles();

            //-------------------------------------------------------------

            app.UseRouting();

            //-------------------------------------------------------------

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
