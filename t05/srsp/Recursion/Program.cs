using System;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("DigitSum(0) = {0}", Rec.DigitSum(0));
        Console.WriteLine("DigitSum(7) = {0}", Rec.DigitSum(7));
        Console.WriteLine("DigitSum(12345) = {0}", Rec.DigitSum(12345));
        Console.WriteLine("DigitSum(1000) = {0}", Rec.DigitSum(1000));

        Console.WriteLine("Pow(2, 0) = {0}", Rec.Pow(2, 0));
        Console.WriteLine("Pow(2, 10) = {0}", Rec.Pow(2, 10));
        Console.WriteLine("Pow(5, 3) = {0}", Rec.Pow(5, 3));
        Console.WriteLine("Pow(7, 1) = {0}", Rec.Pow(7, 1));
    }
}
