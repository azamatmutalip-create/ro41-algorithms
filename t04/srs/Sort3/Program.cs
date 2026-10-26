using System;

Check(3, 1, 2);
Check(1, 2, 3);
Check(3, 2, 1);
Check(2, 2, 1);
Check(5, 5, 5);

static void Check(int a, int b, int c)
{
    Console.Write($"{a} {b} {c} -> ");
    Order.Sort3(ref a, ref b, ref c);
    Console.WriteLine($"{a} {b} {c}");
}

static class Order
{
    public static void Swap(ref int x, ref int y)
    {
        int temp = x;
        x = y;
        y = temp;
    }

    public static void Sort3(ref int a, ref int b, ref int c)
    {
        if (a > b)
        {
            Swap(ref a, ref b);
        }

        if (b > c)
        {
            Swap(ref b, ref c);
        }

        if (a > b)
        {
            Swap(ref a, ref b);
        }
    }
}
