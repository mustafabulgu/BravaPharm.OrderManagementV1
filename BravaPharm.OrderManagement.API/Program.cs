using BravaPharm.OrderManagement.Application;
using BravaPharm.OrderManagement.Persistence;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServiceRegistrations();
builder.Services.AddPersistenceServiceRegistrations(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddCors(options => 
{
    options.AddPolicy("AllowAll", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//seed data
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BravaPharmDbContext>();
    await BravaPharmDbContextSeeder.SeedAsync(dbContext);
}

app.Run();
