public static class ArrayAlgos
{
    public static bool IsSorted(int[] a)
    {
        for (int i = 1; i < a.Length; i++)
        {
            if (a[i - 1] > a[i])
                return false;
        }

        return true;
    }

    public static int BubbleSort(int[] a)
    {
        long comparisons = 0;

        for (int end = a.Length - 1; end > 0; end--)
        {
            bool swapped = false;
            for (int i = 0; i < end; i++)
            {
                comparisons++;
                if (a[i] > a[i + 1])
                {
                    int temp = a[i];
                    a[i] = a[i + 1];
                    a[i + 1] = temp;
                    swapped = true;
                }
            }

            if (!swapped)
                break;
        }

        return checked((int)comparisons);
    }

    public static int CountOccurrences(int[] sortedA, int x)
    {
        int lo = 0;
        int hi = sortedA.Length;

        // Первый индекс, где элемент больше или равен x.
        while (lo < hi)
        {
            int mid = lo + (hi - lo) / 2;
            if (sortedA[mid] < x)
                lo = mid + 1;
            else
                hi = mid;
        }

        int first = lo;
        hi = sortedA.Length;

        // Первый индекс, где элемент строго больше x.
        while (lo < hi)
        {
            int mid = lo + (hi - lo) / 2;
            if (sortedA[mid] <= x)
                lo = mid + 1;
            else
                hi = mid;
        }

        return lo - first;
    }
}
