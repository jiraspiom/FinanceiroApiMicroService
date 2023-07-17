using Contas.Interface;
using Contas.Service;
using financeiro.DataBase;
using financeiro.Interface;
using financeiro.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// 

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("CatalogDatabaseSettingsDEV"));
builder.Services.AddScoped<IMongoContext, MongoContext>();

builder.Services.AddScoped<IContaRepository, ContaRepository>();
builder.Services.AddScoped<IContaService, ContaService>();

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
