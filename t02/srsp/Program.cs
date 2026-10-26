using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine() ?? "";
        BigInteger n;
        bool valid = BigInteger.TryParse(input, out n);

        if (valid && n >= 0)
        {
            BigInteger sum = 0;
            BigInteger count = 0;

            do
            {
                sum = sum + n % 10;
                count = count + 1;
                n = n / 10;
            }
            while (n > 0);

            Console.WriteLine($"Количество цифр: {count}; сумма цифр: {sum}");
        }
        else
        {
            Console.WriteLine("Ошибка: введите целое неотрицательное число.");
        }
    }
}
