using System;

namespace ShoesRestoreC_
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }

        public Cliente(string nome, string endereco)
        {
            Nome = nome;
            Endereco = endereco;
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Endereço: {Endereco}");
        }
    }

}