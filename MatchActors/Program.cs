using MatchActors.Application;
using MatchActors.Domain;
using MatchActors.Domain.MatchFactories;
using MatchActors.Extensions;
using MatchActors.Infrastructure.Database;
using MatchActors.Infrastructure.Database.Commands;
using MatchActors.Infrastructure.ImdbClient.Extensions;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddSingleton<ICommandBuilder, CommandBuilder>();
builder.Services.AddScoped<IActorInfoRepository, ActorInfoRepository>();
builder.Services.AddControllers();
builder.Services.AddSingleton<IMatchersFactory, MatchersFactory>();
builder.Services.AddScoped<IActorFilmingsResolver, ActorFilmingsResolver>();
builder.Services.AddImdbClientApi(builder.Configuration);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerCommon("MatchActorsAPI", "v1", libraryName: Assembly.GetExecutingAssembly().GetName().Name ?? string.Empty);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();