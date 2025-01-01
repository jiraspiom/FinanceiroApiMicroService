using Contas.Interface;
using Contas.Seeds;
using Contas.Service;
using financeiro.DataBase;
using financeiro.Interface;
using financeiro.Repository;
using Microsoft.AspNetCore.Components.Forms;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// 

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("CatalogDatabaseSettings"));
builder.Services.AddScoped<IMongoContext, MongoContext>();

builder.Services.AddScoped<IContaRepository, ContaRepository>();
builder.Services.AddScoped<IContaService, ContaService>();

// servico seed
var serviceProvider = builder.Services.BuildServiceProvider();
var mongoContext = serviceProvider.GetRequiredService<IMongoContext>();
//var instituicaoCollection = mongoContext.Instituicoes;
Seeds.SeedContexto(mongoContext);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});



var app = builder.Build();

app.UseCors("AllowAll");

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
