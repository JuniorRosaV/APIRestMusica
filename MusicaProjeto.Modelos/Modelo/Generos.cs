using System;
using System.Collections.Generic;

namespace MusicaProjeto.Modelos.Modelo
{
    public class Generos
    {
        public Generos(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
            Musicas = new List<Musicas>();
        }
        public Generos()
        {
            Musicas = new List<Musicas>();
        }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public virtual ICollection<Musicas> Musicas { get; set; }
    }
}
