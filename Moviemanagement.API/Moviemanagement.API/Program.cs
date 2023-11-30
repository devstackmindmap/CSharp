using Microsoft.EntityFrameworkCore;
using Moviemanagement.DataAccess.Context;
using Moviemanagement.DataAccess.Implementation;
using Moviemanagement.Domain.Repository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Entity Framework
builder.Services.AddDbContext<MovieManagementDbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("MovieConnection")));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddMvc().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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
