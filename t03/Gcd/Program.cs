using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        string inputA = Console.ReadLine() ?? "";
        string inputB = Console.ReadLine() ?? "";
        BigInteger a;
        BigInteger b;
        bool validA = BigInteger.TryParse(inputA, out a);
        bool validB = BigInteger.TryParse(inputB, out b);

        if (validA && validB && a >= 0 && b >= 0 && (a != 0 || b != 0))
        {
            while (b != 0)
            {
                BigInteger r = a % b;
                a = b;
                b = r;
            }

            Console.WriteLine($"НОД: {a}");
        }
        else
        {
            Console.WriteLine("Ошибка: введите два целых неотрицательных числа, не оба нуля.");
        }
    }
}
