using System;
using System.Globalization;

int count = 0;
int sum = 0;
int fives = 0;
int g = Grades.Read();

while (g != Grades.Stop)
{
    bool valid = Grades.IsValid(g);
    if (valid)
    {
        count++;
        sum += g;
        if (g == Grades.Max)
        {
            fives++;
        }
    }
    else
    {
        Console.WriteLine("Некорректная оценка");
    }

    g = Grades.Read();
}

Grades.PrintStats(count, sum, fives);

static class Grades
{
    public const int Min = 2;
    public const int Max = 5;
    public const int Stop = 0;

    public static int Read()
    {
        return int.TryParse(Console.ReadLine(), out int g) ? g : -1;
    }

    public static bool IsValid(int g)
    {
        return g >= Min && g <= Max;
    }

    public static void PrintStats(int count, int sum, int fives)
    {
        if (count == 0)
        {
            Console.WriteLine("Оценок нет");
        }
        else
        {
            double average = (double)sum / count;
            Console.WriteLine($"Количество оценок: {count}");
            Console.WriteLine($"Сумма оценок: {sum}");
            Console.WriteLine($"Средний балл: {average.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Пятёрок: {fives}");
        }
    }
}
