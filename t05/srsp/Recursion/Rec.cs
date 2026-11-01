using System;

public static class Rec
{
    public static int DigitSum(int n)
    {
        if (n < 0)
            throw new ArgumentOutOfRangeException("n");

        // Базовый случай: сумма цифр однозначного числа равна самому числу.
        if (n < 10)
            return n;

        return n % 10 + DigitSum(n / 10);
    }

    public static long Pow(int x, int n)
    {
        if (n < 0)
            throw new ArgumentOutOfRangeException("n");

        // Базовый случай: любое число в нулевой степени принимаем равным 1.
        if (n == 0)
            return 1L;

        return checked((long)x * Pow(x, n - 1));
    }
}
