using System;

int failed = 0;

Console.WriteLine("BubbleSort");
failed += CheckBubble(Array.Empty<int>(), "{}", 0);
failed += CheckBubble(new[] { 5 }, "{5}", 0);
failed += CheckBubble(new[] { 1, 2, 3, 4, 5 }, "{1, 2, 3, 4, 5}", 4);
failed += CheckBubble(new[] { 5, 4, 3, 2, 1 }, "{1, 2, 3, 4, 5}", 10);
failed += CheckBubble(new[] { 3, 1, 3, 2, 3 }, "{1, 2, 3, 3, 3}", 9);

int[] sorted = new int[1000];
for (int i = 0; i < sorted.Length; i++)
    sorted[i] = i + 1;

int comparisons = ArrayAlgos.BubbleSort(sorted);
bool isSorted = ArrayAlgos.IsSorted(sorted);
bool earlyExitOk = isSorted && comparisons == 999;
Console.WriteLine($"1000 отсортированных элементов | IsSorted после = {isSorted} | сравнений {comparisons} (ожидалось 999) | {Status(earlyExitOk)}");
failed += earlyExitOk ? 0 : 1;

int[] values = { 1, 2, 2, 2, 5, 7 };
Console.WriteLine();
Console.WriteLine($"CountOccurrences для {Format(values)}");
failed += CheckOccurrences(values, 2, 3);
failed += CheckOccurrences(values, 1, 1);
failed += CheckOccurrences(values, 7, 1);
failed += CheckOccurrences(values, 3, 0);
failed += CheckOccurrences(values, 9, 0);

return failed == 0 ? 0 : 1;

static int CheckBubble(int[] values, string expectedAfter, int expectedComparisons)
{
    string before = Format(values);
    bool sortedBefore = ArrayAlgos.IsSorted(values);
    int comparisons = ArrayAlgos.BubbleSort(values);
    string after = Format(values);
    bool sortedAfter = ArrayAlgos.IsSorted(values);
    bool ok = sortedAfter && after == expectedAfter && comparisons == expectedComparisons;

    Console.WriteLine($"{before} -> {after} | IsSorted до = {sortedBefore}, после = {sortedAfter} | сравнений {comparisons} (ожидалось {expectedComparisons}) | {Status(ok)}");
    return ok ? 0 : 1;
}

static int CheckOccurrences(int[] values, int x, int expected)
{
    int count = ArrayAlgos.CountOccurrences(values, x);
    bool ok = count == expected;
    Console.WriteLine($"x = {x} | ожидалось {expected} | получено {count} | {Status(ok)}");
    return ok ? 0 : 1;
}

static string Format(int[] values)
{
    return "{" + string.Join(", ", values) + "}";
}

static string Status(bool ok)
{
    return ok ? "OK" : "FAIL";
}
