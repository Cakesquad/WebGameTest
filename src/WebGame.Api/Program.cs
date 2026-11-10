using Microsoft.OpenApi;
using Swagger.Bootstrap;

namespace WebGame.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.AddServiceDefaults();

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "SwaggerDocument",
                    Description = "A simple ASP.NET Core Web API",
                });
            });
            builder.Services.AddSwaggerBootstrap(options =>
            {
                options.UseExperimentalFeatures = true;
            });

            var app = builder.Build();

            app.MapDefaultEndpoints();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerBootstrap();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
