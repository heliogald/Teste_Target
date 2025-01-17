using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

namespace CodigoParaAnalisarOFaturamentoDiario
{
    public class Program
    {
        public static void Main()
        {
            // Chama o método que processa o faturamento
            ProcessarFaturamento();
        }

        public static void ProcessarFaturamento()
        {
            try
            {
                // Obter o caminho absoluto do arquivo JSON
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = Path.Combine(basePath, "dados.json");

                // Ler o arquivo JSON
                string json = File.ReadAllText(filePath);
                Console.WriteLine("Arquivo JSON lido com sucesso.");

                // Configurar JsonSerializerOptions com o contexto de serialização gerado
                var options = new JsonSerializerOptions
                {
                    TypeInfoResolver = FaturamentoContext.Default
                };

                // Deserializar os dados do JSON para uma lista de objetos Faturamento usando o contexto de serialização
                var faturamentoDiario = JsonSerializer.Deserialize(json, FaturamentoContext.Default.FaturamentoArray);
                Console.WriteLine("Dados deserializados com sucesso.");

                // Verificar os dados deserializados
                foreach (var f in faturamentoDiario)
                {
                    Console.WriteLine($"Dia: {f.dia}, Valor: {f.valor}");
                }

                // Ignorar os dias com faturamento 0
                var faturamentoValido = faturamentoDiario.Where(f => f.valor > 0).ToArray();
                Console.WriteLine($"Número de dias com faturamento válido: {faturamentoValido.Length}");

                if (faturamentoValido.Length == 0)
                {
                    Console.WriteLine("Não há dados de faturamento válidos.");
                    return;
                }

                // Calcular a média mensal ignorando os dias sem faturamento
                double mediaMensal = faturamentoValido.Average(f => f.valor);

                // Encontrar o menor e maior valor de faturamento
                double menorFaturamento = faturamentoValido.Min(f => f.valor);
                double maiorFaturamento = faturamentoValido.Max(f => f.valor);

                // Calcular o número de dias com faturamento superior à média
                int diasAcimaDaMedia = faturamentoValido.Count(f => f.valor > mediaMensal);

                // Exibir os resultados
                Console.WriteLine($"Menor valor de faturamento: R${menorFaturamento:F2}");
                Console.WriteLine($"Maior valor de faturamento: R${maiorFaturamento:F2}");
                Console.WriteLine($"Número de dias com faturamento superior à média: {diasAcimaDaMedia}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Erro: O arquivo 'dados.json' não foi encontrado.");
                Console.WriteLine(ex.Message);
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Erro: O arquivo 'dados.json' contém um formato inválido.");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro inesperado.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}











