using System;

namespace ShoesRestoreC_
{
    public class Sapateiro
    {
        public string Nome { get; set; }
        public string Experiencia { get; set; }

        public Sapateiro(string nome, string experiencia)
        {
            Nome = nome;
            Experiencia = experiencia;
        }

        //defeito à lista de defeitos do sapato
        public void RegistrarDefeito(Sapato sapato, Defeito defeito)
        {
            //adiciona o defeito à lista de defeitos, em vez de substituir
            sapato.Defeitos.Add(defeito);
            Console.WriteLine($"{Nome} registrou o defeito '{defeito.Descricao}' no {sapato.Modelo}.");
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Sapateiro: {Nome}, Experiência: {Experiencia}");
        }
    }
}
