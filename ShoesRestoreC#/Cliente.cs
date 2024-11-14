using System;

namespace ShoesRestoreC_
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Contato { get; set; }

        public Cliente(string nome, string endereco, string cpf, string email, string contato)
        {
            Nome = nome;
            Endereco = endereco;
            CPF = cpf;
            Email = email;
            Contato = contato;
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Endereço: {Endereco}");
            Console.WriteLine($"CPF: {CPF}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Contato: {Contato}");
        }
    }

}