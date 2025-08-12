using MusicaProjeto.Modelos.Modelo;

public class Musicas
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    // Chave estrangeira
    public int ArtistaId { get; set; }
    public virtual Artistas? Artista { get; set; }

    public virtual ICollection<Generos> Generos { get; set; } = new List<Generos>();

    public int Duracao { get; set; }
    public bool Disponivel { get; set; }
    public int? AnoLancamento { get; set; }

    public string DescricaoResumida =>
        $"A Música {Nome} pertence à banda {Artista?.Nome ?? "Desconhecida"}";

    public Musicas() { }

    public Musicas(Artistas artista, string nome, int ano, ICollection<Generos> generos)
    {
        Artista = artista;
        Nome = nome;
        AnoLancamento = ano;
        Generos = generos;
    }

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome da Música: {Nome}");
        Console.WriteLine($"Artista: {Artista?.Nome ?? "Desconhecido"}");
        Console.WriteLine($"Duração da Música: {Duracao} segundos");
        Console.WriteLine(Disponivel ? "Música disponível." : "Música indisponível.");
    }
}
