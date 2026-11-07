using System;
using System.Text;

public static class TextTools
{
    public static int CountWords(string s)
    {
        return s.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public static bool IsPalindrome(string s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            if (char.IsWhiteSpace(s[left]))
            {
                left++;
                continue;
            }

            if (char.IsWhiteSpace(s[right]))
            {
                right--;
                continue;
            }

            if (char.ToUpperInvariant(s[left]) != char.ToUpperInvariant(s[right]))
                return false;

            left++;
            right--;
        }

        return true;
    }

    public static string Initials(string fullName)
    {
        string[] words = fullName.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
        var result = new StringBuilder();

        foreach (string word in words)
        {
            if (result.Length > 0)
                result.Append(' ');

            result.Append(char.ToUpperInvariant(word[0]));
            result.Append('.');
        }

        return result.ToString();
    }

    public static string Repeat(string s, int n)
    {
        if (n <= 0 || s.Length == 0)
            return string.Empty;

        var result = new StringBuilder();
        for (int i = 0; i < n; i++)
            result.Append(s);

        return result.ToString();
    }
}
