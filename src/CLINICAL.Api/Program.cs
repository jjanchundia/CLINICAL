using CLINICAL.Persistence.Extensions;
using CLINICAL.Application.UseCase.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Agregamos referencia a proyecto CLINICAL,Persistence, para usar evento
builder.Services.AddInjectionPersistence();
//Agregamos referencia a proyecto Application.UseCase.Extensions, para usar metodo
builder.Services.AddInjectionApplication();

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
