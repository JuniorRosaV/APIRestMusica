using Musica_Projeto.Banco;

namespace ScreenSound.Menus;

internal class MenuMostrarMusicas : Menu
{
    public override void Executar(DAL<Artistas> ArtistaDAL)
    {
        base.Executar(ArtistaDAL);
        ExibirTituloDaOpcao("Exibir detalhes do artista");
        Console.Write("Digite o nome do artista que deseja conhecer melhor: ");
        string nomeDoArtista = Console.ReadLine()!;
        var recuperarArtista = ArtistaDAL.RecuperarPor(a => a.Nome == nomeDoArtista);
        if (recuperarArtista is not null)
        {
            Console.WriteLine("\nDiscografia:");
            recuperarArtista.ExibirDiscografia();
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nO artista {nomeDoArtista} não foi encontrado!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
