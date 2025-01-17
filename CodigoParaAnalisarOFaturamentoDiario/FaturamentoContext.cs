using System.Text.Json.Serialization;

namespace CodigoParaAnalisarOFaturamentoDiario
{
    [JsonSerializable(typeof(Faturamento[]))]
    internal partial class FaturamentoContext : JsonSerializerContext
    {
    }
}







