namespace InverterCaracteresDeUmaString
{
    using System;

    class Program
    {
        static void Main()
        {
            // String de entrada (pode ser modificada ou informada pelo usuário)
            Console.Write("Digite uma string para inverter: ");
            string input = Console.ReadLine();

            // Convertendo a string para um array de caracteres
            char[] caracteres = input.ToCharArray();

            // Invertendo os caracteres manualmente
            int left = 0;
            int right = caracteres.Length - 1;

            while (left < right)
            {
                // Troca de caracteres
                char temp = caracteres[left];
                caracteres[left] = caracteres[right];
                caracteres[right] = temp;

                left++;
                right--;
            }

            // Convertendo o array de caracteres de volta para string e exibindo o resultado
            string resultado = new string(caracteres);
            Console.WriteLine($"String invertida: {resultado}");
        }
    }

}
