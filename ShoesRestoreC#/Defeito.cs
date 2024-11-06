using System;

namespace ShoesRestoreC_
{
    public class Defeito
    {
        public string Descricao { get; set; }

        public Defeito(string descricao)
        {
            Descricao = descricao;
        }

        public void ExibirDetalhes()
        {
            Console.WriteLine($"Defeito: {Descricao}");
        }
    }
}
