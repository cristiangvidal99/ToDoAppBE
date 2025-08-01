
using Api.Interfaces;
using Api.Repository;
using Api.Services;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddHealthChecks();
            builder.Services.AddScoped<ITaskService, TaskService>();
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhostFrontend", policy =>
                {
                    policy.WithOrigins("http://localhost:5173", "https://spontaneous-pudding-386f9f.netlify.app") // URL del frontend
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });


            builder.Services.AddHttpClient<ITaskRepository, TaskRepository>((sp, client) =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                client.BaseAddress = new Uri(configuration["baseUrl"]!);
                client.DefaultRequestHeaders.Add("apikey", configuration["apiKey"]!);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", configuration["apiKey"]);
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }
            app.UseHttpsRedirection();
            app.MapHealthChecks("/healthcheck");
            app.UseCors("AllowLocalhostFrontend");
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
