using System.ComponentModel.DataAnnotations.Schema;

public class Artistas
{
    public virtual ICollection<Musicas> Musicas { get; set; } = new List<Musicas>();

    public Artistas() { }

    public Artistas(string nome, string bio)
    {
        Nome = nome;
        Bio = bio;
        FotoPerfil = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
    }

    public string Nome { get; set; } = string.Empty;
    public string FotoPerfil { get; set; } = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
    public string Bio { get; set; } = string.Empty;

    public int Id { get; set; }

    public void AdicionarMusica(Musicas musica)
    {
        Musicas.Add(musica);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia do artista {Nome}");
        foreach (var musica in Musicas)
        {
            Console.WriteLine($"Música: {musica.Nome} - Lançamento: {musica.AnoLancamento}");
        }
    }

    public override string ToString()
    {
        return $@"Id: {Id}
            Nome: {Nome}
            Foto de Perfil: {FotoPerfil}
            Bio: {Bio}";
    }
}
