using Microsoft.AspNetCore.Mvc;
using Musica_Projeto.Banco;
using MusicaProjeto.API.Requests;
using MusicaProjeto.Modelos.Modelo;

namespace MusicaProjeto.API.Endpoints
{
    public static class GenerosExtends
    {
        public static void AddEndPointsGeneros(this WebApplication app)
        {
            app.MapGet("/Generos", ([FromServices] DAL<Generos> dal) =>
            {
                return Results.Ok(dal.Listar());
            }).WithTags("Generos"); 

            app.MapGet("/Generos/{nome}", ([FromServices] DAL<Generos> dal, string nome) =>
            {
                var Generos = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));

                if (Generos is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(Generos);
            }).WithTags("Generos");

            app.MapPost("/Generos", ([FromServices] DAL<Generos> dal, [FromBody] GenerosRequest GenerosRequest) =>
            {
                var generos = new Generos(GenerosRequest.nome, GenerosRequest.descricao);
                dal.Adicionar(generos);
                return Results.Ok();
            }).WithTags("Generos");

            app.MapDelete("/Generos/{Id}", ([FromServices] DAL<Generos> dal, int id) =>
            {
                var genero = dal.RecuperarPor(a => a.Id.Equals(id));
                if (genero is null)
                {
                    return Results.NotFound();
                }
                dal.Deletar(genero);
                return Results.NoContent();
            }).WithTags("Generos");
        }
    }
}
