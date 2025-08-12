using Microsoft.AspNetCore.Mvc;
using Musica_Projeto.Banco;
using MusicaProjeto.API.Requests;

namespace MusicaProjeto.API.Endpoints
{
    public static class ArtistasExtends
    {
        public static void AddEndPointsArtistas(this WebApplication app)
        {
            app.MapGet("/Artistas", ([FromServices] DAL<Artistas> dal) =>
            {
                return Results.Ok(dal.Listar());
            }).WithTags("Artistas"); 

            app.MapGet("/Artistas/{nome}", ([FromServices] DAL<Artistas> dal, string nome) =>
            {
                var Artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));

                if (Artista is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(Artista);
            }).WithTags("Artistas"); 

            app.MapPost("/Artistas", ([FromServices] DAL<Artistas> dal, [FromBody] ArtistasRequest artistasRequest) =>
            {
                var artistas = new Artistas(artistasRequest.nome, artistasRequest.bio);
                dal.Adicionar(artistas);
                return Results.Ok();
            }).WithTags("Artistas"); 

            app.MapDelete("/Artistas/{Id}", ([FromServices] DAL<Artistas> dal, int id) =>
            {
                var artista = dal.RecuperarPor(a => a.Id.Equals(id));
                if (artista is null)
                {
                    return Results.NotFound();
                }
                dal.Deletar(artista);
                return Results.NoContent();
            }).WithTags("Artistas"); 

            app.MapPut("/Artistas", ([FromServices] DAL<Artistas> dal, [FromBody] ArtistaRequestEdit artistaRequestEdit) => {
                var artistaAAtualizar = dal.RecuperarPor(a => a.Id == artistaRequestEdit.Id);
                if (artistaAAtualizar is null)
                {
                    return Results.NotFound();
                }
                artistaAAtualizar.Nome = artistaRequestEdit.nome;
                artistaAAtualizar.Bio = artistaRequestEdit.bio;
                dal.Atualizar(artistaAAtualizar);
                return Results.Ok();
            }).WithTags("Artistas"); 
        }
    }
}
