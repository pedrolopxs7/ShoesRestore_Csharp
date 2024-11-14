using ShoesRestoreC_;
using System.Collections.Generic;
using System;

public class Sapato
{
    public string Modelo { get; set; }
    public decimal Preco { get; set; }
    public Cliente Cliente { get; set; }
    public List<Defeito> Defeitos { get; set; }  // lista de defeitos

    public Sapato(string modelo, decimal preco)
    {
        Modelo = modelo;
        Defeitos = new List<Defeito>();  // Inicializando a lista de defeitos
        Preco = preco;
    }

    public void ExibirInformacoes()
    {
        Console.WriteLine($"Modelo: {Modelo}, Preço: R$ {Preco}");

        // verifica se o sapato tem defeitos registrados
        if (Defeitos.Count > 0)
        {
            Console.WriteLine($"Cliente: {Cliente.Nome}");
            Console.WriteLine("Defeitos:");
            foreach (var defeito in Defeitos)
            {
                Console.WriteLine($"- {defeito.Descricao}");
            }
        }
        else
        {
            Console.WriteLine("Nenhum defeito registrado.");
        }
    }
}
