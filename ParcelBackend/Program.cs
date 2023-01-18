using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ParcelBackend.Models;

var builder = WebApplication.CreateBuilder(args);
string ApiCorsPolicy = "_apiCorsPolicy";
// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("MyDBConnection")));
builder.Services.AddEntityFrameworkNpgsql()
               .AddDbContext<DatabaseContext>()
               .BuildServiceProvider();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy(ApiCorsPolicy, builder => {
    builder.WithOrigins("https://localhost:7126").AllowAnyOrigin();
//.AllowAnyMethod()
//.AllowAnyHeader()
//.AllowCredentials();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(ApiCorsPolicy);

app.MapControllers();

app.Run();

