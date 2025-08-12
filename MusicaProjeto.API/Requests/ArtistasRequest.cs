namespace MusicaProjeto.API.Requests
{
    public record ArtistasRequest(string nome, string bio);
    public record ArtistaRequestEdit(int Id, string nome, string bio);

}
