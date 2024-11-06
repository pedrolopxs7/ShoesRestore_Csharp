using System;
using System.Collections.Generic;

namespace ShoesRestoreC_
{
    public class Sapato
    {
        public string Modelo { get; set; }
        public decimal Preco { get; set; }
        public Cliente Cliente { get; set; }
        public Defeito Defeito { get; set; } // Defeito associado ao sapato

        public Sapato(string modelo, decimal preco)
        {
            Modelo = modelo;
            Preco = preco;
            Defeitos = new List<Defeito>();  // Inicializando a lista de defeitos
            // Defeitos = new List<Defeito>();
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Modelo: {Modelo}, Preço: R$ {Preco}");
            if (Defeito != null)
            {
                    Console.WriteLine($"Cliente: {Cliente.Nome}");
                    Console.WriteLine($"Defeito: {Defeito.Descricao}");
            }
            else
            {
                Console.WriteLine("Nenhum defeito registrado.");
            }
        }
    }
}
