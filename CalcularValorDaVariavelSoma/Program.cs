namespace CodigoParaAnalisarOFaturamentoDiario
{
    using System;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    class Program
    {
        public class Faturamento
        {
            public int Dia { get; set; }
            public double Valor { get; set; }
        }

        static void Main()
        {
            // Ler o arquivo JSON
            string json = File.ReadAllText("dados.json");

            // Deserializar os dados do JSON para uma lista de objetos Faturamento
            var faturamentoDiario = JsonConvert.DeserializeObject<Faturamento[]>(json);

            // Ignorar os dias com faturamento 0
            var faturamentoValido = faturamentoDiario.Where(f => f.Valor > 0).ToArray();

            // Calcular a média mensal
            double mediaMensal = faturamentoValido.Average(f => f.Valor);

            // Encontrar o menor e maior valor de faturamento
            double menorFaturamento = faturamentoValido.Min(f => f.Valor);
            double maiorFaturamento = faturamentoValido.Max(f => f.Valor);

            // Calcular o número de dias com faturamento superior à média
            int diasAcimaDaMedia = faturamentoValido.Count(f => f.Valor > mediaMensal);

            // Exibir os resultados
            Console.WriteLine($"Menor valor de faturamento: R${menorFaturamento:F2}");
            Console.WriteLine($"Maior valor de faturamento: R${maiorFaturamento:F2}");
            Console.WriteLine($"Número de dias com faturamento superior à média: {diasAcimaDaMedia}");
        }
    }
}

