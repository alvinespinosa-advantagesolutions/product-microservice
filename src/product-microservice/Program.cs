using product_microservice.Constants;
using product_microservice.Extensions;
using product_microservice.Models.settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureServiceOptions(builder.Configuration);

var auth0Settings = builder.Configuration.GetSection(Application.Settings.Auth0).Get<Auth0Settings>();
builder.Services.ConfigureAuthentication(auth0Settings, builder.Environment);
builder.Services.ConfigureAuthorization();

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
