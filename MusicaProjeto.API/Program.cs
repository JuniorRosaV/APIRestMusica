using Microsoft.AspNetCore.Mvc;
using Musica_Projeto.Banco;
using MusicaProjeto.API.Endpoints;
using MusicaProjeto.Modelos.Modelo;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MusicaProjectContext>();
builder.Services.AddTransient<DAL<Artistas>>();
builder.Services.AddTransient<DAL<Musicas>>();
builder.Services.AddTransient<DAL<Generos>>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>
    (options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.AddEndPointsArtistas();
app.AddEndPointsMusicas();
app.AddEndPointsGeneros();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
