using Microsoft.AspNetCore.Mvc;
using Musica_Projeto.Banco;
using MusicaProjeto.API.Requests;
using MusicaProjeto.Modelos.Modelo;
using ScreenSound.API.Requests;

namespace MusicaProjeto.API.Endpoints
{
    public static class MusicasExtends
    {
        public static void AddEndPointsMusicas(this WebApplication app)
        {
            app.MapGet("/Musicas", ([FromServices] DAL<Musicas> dal) =>
            {
                return Results.Ok(dal.Listar());
            }).WithTags("Musicas");

            app.MapGet("/Musicas/{nome}", ([FromServices] DAL<Musicas> dal, string nome) =>
            {
                var musica = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
                if (musica is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(musica);
            }).WithTags("Musicas");
            app.MapPost("/Musicas", ([FromServices] DAL<Musicas> dal, [FromServices] DAL<Generos> dalGenero, [FromBody] MusicaRequest musicasRequest) =>
            {

                var musicas = new Musicas
                {
                    ArtistaId = musicasRequest.ArtistaId,
                    Nome = musicasRequest.nome,
                    AnoLancamento = musicasRequest.anoLancamento,
                    Generos = musicasRequest.Generos is not null ?
                    GeneroRequestConverter(musicasRequest.Generos, dalGenero) : new List<Generos>()
                };


                dal.Adicionar(musicas);
                return Results.Ok();
            }).WithTags("Musicas");

            app.MapDelete("/Musicas/{Id}", ([FromServices] DAL<Musicas> dal, int id) =>
            {
                var musica = dal.RecuperarPor(a => a.Id.Equals(id));
                if (musica is null)
                {
                    return Results.NotFound();
                }
                dal.Deletar(musica);
                return Results.NoContent();
            }).WithTags("Musicas");

            app.MapPut("/Musicas", ([FromServices] DAL<Musicas> dal, [FromBody] Musicas musica) => {
                var MusicaAtualizar = dal.RecuperarPor(a => a.Id.Equals(musica.Id));
                if (MusicaAtualizar is null)
                {
                    return Results.NotFound();
                }
                MusicaAtualizar.Nome = musica.Nome;
                MusicaAtualizar.Artista = musica.Artista;
                MusicaAtualizar.Duracao = musica.Duracao;
                MusicaAtualizar.Disponivel = musica.Disponivel;
                MusicaAtualizar.AnoLancamento = musica.AnoLancamento;
                MusicaAtualizar.Generos = musica.Generos;

                dal.Atualizar(MusicaAtualizar);
                return Results.Ok();
            }).WithTags("Musicas");
        }

        private static ICollection<Generos> GeneroRequestConverter(ICollection<GenerosRequest> generos, DAL<Generos> dalGenero)
        {
            var listaDeGeneros = new List<Generos>();
            foreach (var item in generos)
            {
                var entity = RequestToEntity(item);
                var genero = dalGenero.RecuperarPor(g => g.Nome.ToUpper().Equals(item.nome.ToUpper()));
                if (genero is not null)
                {
                    listaDeGeneros.Add(genero);
                }
                else
                {
                    listaDeGeneros.Add(entity);
                }
            }

            return listaDeGeneros;
        }
        private static Generos RequestToEntity(GenerosRequest genero)
        {
            return new Generos() { Nome = genero.nome, Descricao = genero.descricao };
        }
    }
}
