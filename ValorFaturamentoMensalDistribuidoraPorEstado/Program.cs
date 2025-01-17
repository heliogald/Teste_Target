namespace ValorFaturamentoMensalDistribuidoraPorEstado
{
    using System;

    class Program
    {
        static void Main()
        {
            // Faturamento de cada estado
            double sp = 67836.43;
            double rj = 36678.66;
            double mg = 29229.88;
            double es = 27165.48;
            double outros = 19849.53;

            // Calculando o faturamento total
            double totalFaturamento = sp + rj + mg + es + outros;

            // Calculando o percentual de cada estado
            double percentualSP = (sp / totalFaturamento) * 100;
            double percentualRJ = (rj / totalFaturamento) * 100;
            double percentualMG = (mg / totalFaturamento) * 100;
            double percentualES = (es / totalFaturamento) * 100;
            double percentualOutros = (outros / totalFaturamento) * 100;

            // Exibindo os resultados
            Console.WriteLine($"Percentual de SP: {percentualSP:F2}%");
            Console.WriteLine($"Percentual de RJ: {percentualRJ:F2}%");
            Console.WriteLine($"Percentual de MG: {percentualMG:F2}%");
            Console.WriteLine($"Percentual de ES: {percentualES:F2}%");
            Console.WriteLine($"Percentual de Outros: {percentualOutros:F2}%");
        }
    }

}
