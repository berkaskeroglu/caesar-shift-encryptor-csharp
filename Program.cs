using System;
using System.Globalization;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.WriteLine("What is the word?:");
        string input = Console.ReadLine()?.ToUpper(new CultureInfo("tr-TR")) ?? "";

        Console.WriteLine("What is the operation? 1-Encrypt 2-Decrypt");
        string operation = Console.ReadLine();

        char[] alphabet = { 'A', 'B', 'C', 'Ç', 'D', 'E', 'F', 'G', 'Ğ', 'H', 'I', 'İ', 'J', 'K', 'L', 'M', 'N',
                            'O', 'Ö', 'P', 'R', 'S', 'Ş', 'T', 'U', 'Ü', 'V', 'Y', 'Z' };
        int n = alphabet.Length;

        int shift = operation == "1" ? 3 : operation == "2" ? -3 : 0;
        if (shift == 0)
        {
            Console.WriteLine("Invalid operation.");
            return;
        }

        char[] result = new char[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            int index = Array.IndexOf(alphabet, input[i]);
            if (index == -1)
            {
                result[i] = input[i];
            }
            else
            {
                int newIndex = (index + shift) % n;
                if (newIndex < 0) newIndex += n;
                result[i] = alphabet[newIndex];
            }
        }

        Console.WriteLine((shift > 0 ? "Encrypted" : "Decrypted") + " word: " + new string(result));
    }
}
