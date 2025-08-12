using Musica_Projeto.Banco;


namespace ScreenSound.Menus;

internal class MenuRegistrarArtista : Menu
{
    public override void Executar(DAL<Artistas> ArtistaDAL)
    {
        base.Executar(ArtistaDAL);
        ExibirTituloDaOpcao("Registro dos Artistas");
        Console.Write("Digite o nome do artista que deseja registrar: ");
        var nomeDoArtista = Console.ReadLine()!;
        Console.Write("Digite a bio do artista que deseja registrar: ");
        string bioDoArtista = Console.ReadLine()!;
        Artistas artista = new Artistas(nomeDoArtista, bioDoArtista);
        ArtistaDAL.Adicionar(artista);
        Console.WriteLine($"O artista {nomeDoArtista} foi registrado com sucesso!");
        Thread.Sleep(4000);
        Console.Clear();
    }
}
