using Musica_Projeto.Banco;

namespace ScreenSound.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artistas> ArtistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}
