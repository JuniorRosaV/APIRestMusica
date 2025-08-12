
using Musica_Projeto.Banco;

namespace ScreenSound.Menus;

internal class MenuMostrarArtistas : Menu
{
    public override void Executar(DAL<Artistas> ArtistaDAL)
    {
        base.Executar(ArtistaDAL);
        ExibirTituloDaOpcao("Exibindo todos os artistas registradas na nossa aplicação");

        foreach (var artista in ArtistaDAL.Listar())
        {
            Console.WriteLine($"Artista: {artista}");
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
