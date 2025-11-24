using Microsoft.EntityFrameworkCore;
using SubscriberSystem.Data;
using SubscriberSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<SubscriberDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SubscriberDb")));

builder.Services.AddScoped<ISubscriberService, SubscriberService>();

//enable CORS in the subscriber API to fetch data from the AdSystem frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAdSystemFrontend",
        policy =>
        {
            policy.WithOrigins("https://localhost:7294")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAdSystemFrontend");

app.MapControllers();

app.Run();
