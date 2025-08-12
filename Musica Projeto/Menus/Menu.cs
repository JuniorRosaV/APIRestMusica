using Musica_Projeto.Banco;

namespace ScreenSound.Menus;

public class Menu
{
    public void ExibirTituloDaOpcao(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos + "\n");
    }
    public virtual void Executar(DAL<Artistas> ArtistaDAL)
    {
        Console.Clear();
    }
}
