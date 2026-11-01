using System;

public static class ArrayOps
{
    public static int Sum(int[] a)
    {
        if (a == null)
            throw new ArgumentNullException("a");

        int sum = 0;
        for (int i = 0; i < a.Length; i++)
            sum = checked(sum + a[i]);
        return sum;
    }

    public static int IndexOfMin(int[] a)
    {
        if (a == null)
            throw new ArgumentNullException("a");
        if (a.Length == 0)
            throw new ArgumentException("Массив должен быть непустым.", "a");

        int min = a[0];
        int minIndex = 0;
        for (int i = 1; i < a.Length; i++)
        {
            // Строгое сравнение сохраняет индекс первого минимума.
            if (a[i] < min)
            {
                min = a[i];
                minIndex = i;
            }
        }
        return minIndex;
    }

    public static int CountGreater(int[] a, int x)
    {
        if (a == null)
            throw new ArgumentNullException("a");

        int count = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] > x)
                count++;
        }
        return count;
    }

    public static void Reverse(int[] a)
    {
        if (a == null)
            throw new ArgumentNullException("a");

        for (int i = 0; i < a.Length / 2; i++)
        {
            int j = a.Length - 1 - i;
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}
