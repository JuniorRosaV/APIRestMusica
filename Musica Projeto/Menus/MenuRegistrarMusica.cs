using Musica_Projeto.Banco;
using MusicaProjeto.Modelos.Modelo;

namespace ScreenSound.Menus;

internal class MenuRegistrarMusica : Menu
{
    public override void Executar(DAL<Artistas> ArtistaDAL)
    {
        base.Executar(ArtistaDAL);
        ExibirTituloDaOpcao("Registro de músicas");
        Console.Write("Digite o artista cuja música deseja registrar: ");
        string nomeDoArtista = Console.ReadLine()!;
        var recuperarArtista = ArtistaDAL.RecuperarPor(a => a.Nome == nomeDoArtista);

        if (recuperarArtista is not null)
        {
            Console.Write("Agora digite o título da música: ");
            string tituloDaMusica = Console.ReadLine()!;

            Console.Write("Agora digite o ano de lançamento da música: ");
            if (!int.TryParse(Console.ReadLine(), out int anoDaMusica))
            {
                Console.WriteLine("Ano inválido. Operação cancelada.");
                Thread.Sleep(3000);
                Console.Clear();
                return;
            }

            Console.Write("Digite os gêneros da música separados por vírgula (ex: Rock, Pop): ");
            string generosEntrada = Console.ReadLine()!;

            // Criar lista de Generos
            var listaGeneros = new List<Generos>();
            if (!string.IsNullOrWhiteSpace(generosEntrada))
            {
                var generosSplit = generosEntrada.Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (var g in generosSplit)
                {
                    listaGeneros.Add(new Generos { Nome = g.Trim() });
                }
            }

            var musica = new Musicas(recuperarArtista, tituloDaMusica, anoDaMusica, listaGeneros);
           

            recuperarArtista.AdicionarMusica(musica);

            ArtistaDAL.Atualizar(recuperarArtista);

            Console.WriteLine($"A música {tituloDaMusica} de {nomeDoArtista} foi registrada com sucesso!");
            Thread.Sleep(4000);
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
