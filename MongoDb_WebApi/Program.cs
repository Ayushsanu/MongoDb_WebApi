
using MongoDB.Driver;
using MongoDb_WebApi.Interfaces;

namespace MongoDb_WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.Configure<MongoDbConnection>(builder.Configuration.GetSection(nameof(MongoDbConnection)));
            builder.Services.AddSingleton<IMongoClient>(s =>
            new MongoClient(builder.Configuration.GetValue<string>("MongoDbConnection:Connection")));
            builder.Services.AddScoped<IUserService,UserService> ();

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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
