using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Localization;
using SalesWeb_Mvc.Data;
using SalesWeb_Mvc.Services;

namespace SalesWebMvc
{
    class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Estabelece o banco de dados usado
            builder.Services.AddDbContext<SalesWeb_MvcContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("SalesWeb_MvcContext"),
                    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("SalesWeb_MvcContext")),
                        builder => builder.MigrationsAssembly("SalesWebMvc")));

            builder.Services.AddScoped<SeedingService>();
            builder.Services.AddScoped<SellerService>();
            builder.Services.AddScoped<DepartamentService>();
            builder.Services.AddScoped<SalesRecordService>();
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            var enUs = new CultureInfo("en-US");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = new List<CultureInfo> { enUs },
                SupportedUICultures = new List<CultureInfo> { enUs }
            };

            app.UseRequestLocalization(localizationOptions);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                //Como nao tem mais a classe startup eh aqui que insere o metodo para fazer inclusão no DB
                //usando o obejeto instanciado "app"
                app.Services.CreateScope()
                    .ServiceProvider.GetRequiredService<SeedingService>().Seed();
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