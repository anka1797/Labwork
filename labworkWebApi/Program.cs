using AutoMapper;
using labworkData;
using labworkWebApi.Configuration;
using labworkWebApi.Services;
using Microsoft.EntityFrameworkCore;

namespace labworkWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //����������� � ����
            builder.Services.AddDbContext<GameContext>(options => options.UseSqlite("Data Source = game.db"));

            //����������� ����� ����
            builder.Services.Configure<MailConfig>(builder.Configuration.GetSection("MailConfig"));

            //����� ��������� ������ �������� ����� ������� dotnet run TEST_PARAM=111
            //���� �������� ����� ���(����������������), �� �� ����� �� ���������� �����
            //var testParam = builder.Configuration.GetValue<string>("TEST_PARAM");
            //Console.WriteLine(testParam);
            //autoMapper config
            var mapper = new MapperConfiguration(mc => mc.AddProfile<MapperProfile>())
                    .CreateMapper();

            builder.Services.AddSingleton(mapper);

            //�������� ����� �������� (�����������)
            builder.Services.AddSingleton<SingletonService>();
            builder.Services.AddScoped<ScopedService>();
            builder.Services.AddTransient<TransientService>();
            builder.Services.AddTransient<Transient2Service>();

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
