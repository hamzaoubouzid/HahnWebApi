using Hahn.Services.Contract.Contract;
using Hahn.Services.EntityFramwork.Context;
using Hahn.Services.EntityFramwork.ImplmentationRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<HahnAppContext>(options => options.UseSqlServer(
     builder.Configuration.GetConnectionString("HahnDB")
));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// services  Contrat Sql
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
// services  Contrat MongoDb


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
