using System;

internal static class Program
{
    private static void Main()
    {
        Show(new int[] { 4, 1, 7, 3, 9 });
        Show(new int[] { 5 });
        Show(new int[] { -2, -7, -4 });
        Show(new int[] { 2, 2, 2 });
    }

    private static void Show(int[] a)
    {
        Console.WriteLine("Original: {0}", Format(a));
        Console.WriteLine("Sum = {0}", ArrayOps.Sum(a));
        Console.WriteLine("IndexOfMin = {0}", ArrayOps.IndexOfMin(a));
        Console.WriteLine("CountGreater(x = 2) = {0}", ArrayOps.CountGreater(a, 2));
        ArrayOps.Reverse(a);
        Console.WriteLine("After Reverse: {0}", Format(a));
        Console.WriteLine();
    }

    private static string Format(int[] a)
    {
        return "{" + string.Join(", ", a) + "}";
    }
}
