using Character.Repository;
using Character.Repository.Abstraction;
using Character.Business;
using Character.Business.Abstraction;
using Microsoft.EntityFrameworkCore;
using Character.Business.Kafka;
using Character.Business.Profiles;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CharacterDbContext>(op =>
    op.UseSqlServer("name=ConnectionStrings:CharacterDbContext",
    a => a.MigrationsAssembly("Character.API")));
builder.Services.AddScoped<IBusiness, Business>();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddKafkaProducerService<KafkaTopicsOutput, ProducerService>(builder.Configuration);
object value = builder.Services.AddAutoMapper(typeof(AssemblyMarker));
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
