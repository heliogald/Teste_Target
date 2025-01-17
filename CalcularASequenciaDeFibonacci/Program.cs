namespace CalcularASequenciaDeFibonacci
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static List<int> Fibonacci(int n)
        {
            List<int> fibSequence = new List<int> { 0, 1 };
            while (fibSequence[fibSequence.Count - 1] < n)
            {
                fibSequence.Add(fibSequence[fibSequence.Count - 1] + fibSequence[fibSequence.Count - 2]);
            }
            return fibSequence;
        }

        static void Main()
        {
            Console.Write("Informe um número para verificar se pertence à sequência de Fibonacci: ");
            int numero = int.Parse(Console.ReadLine());

            List<int> fibSequence = Fibonacci(numero);

            if (fibSequence.Contains(numero))
            {
                Console.WriteLine($"O número {numero} pertence à sequência de Fibonacci!");
            }
            else
            {
                Console.WriteLine($"O número {numero} NÃO pertence à sequência de Fibonacci.");
            }
        }
    }

}
