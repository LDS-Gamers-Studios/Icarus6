using Icarus.Discord;

using Microsoft.EntityFrameworkCore;

namespace Icarus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddJsonFile("config.json", optional: false, reloadOnChange: false);

            // Add services to the container.
            builder.Services.AddScoped<DataContext>();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<DiscordBotService>();
            var app = builder.Build();

            if (builder.Configuration["sql:autoMigrate"].ToLower() == "true")
            {
                using var scope = app.Services.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                db.Database.Migrate();
            }

            app.Services.GetService<DiscordBotService>();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}