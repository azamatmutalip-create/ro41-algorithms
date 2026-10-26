using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine() ?? "";
        BigInteger total;
        bool valid = BigInteger.TryParse(input, out total);

        if (valid && total >= 0)
        {
            BigInteger hours = total / 3600;
            BigInteger minutes = (total % 3600) / 60;
            BigInteger seconds = total % 60;
            Console.WriteLine($"{hours} ч {minutes} мин {seconds} с");
        }
        else
        {
            Console.WriteLine("Ошибка: введите целое неотрицательное число секунд.");
        }
    }
}
