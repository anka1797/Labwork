
using labworkWebApp.Models.Game;
using labworkWebApp.Services;

namespace labworkWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //подключение к базе
            //builder.Services.AddDbContext<GameContext>(options => options.UseSqlite("Data Source = game.db"));

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddScoped<GameApiService>();
            builder.Services.AddHttpClient("GameApi", httpClient =>
            {
                httpClient.BaseAddress = new Uri("http://localhost:5272");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Game}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
