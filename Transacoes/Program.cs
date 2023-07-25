using financeiro.DataBase;
using Pagamentos.DataBase;
using Pagamentos.Interface;
using Pagamentos.Repository;
using Pagamentos.Service;
using Pagamentos.Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("CatalogDatabaseSettingsDEV"));

builder.Services.AddHealthChecks().AddCheck<MongoHealthCheck>("MongoDBConnectionCheck");
builder.Services.AddScoped<IMongoContexto, MongoContexto>();

builder.Services.AddScoped<IDespesaRepository, DespesaRepository>();
builder.Services.AddScoped<IDespesaService, DespesaService>();
builder.Services.AddScoped<IReceitaRepository, ReceitaRepository>();
builder.Services.AddScoped<IReceitaService, ReceitaService>();


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