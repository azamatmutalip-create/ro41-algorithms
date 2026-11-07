using System;
using System.Collections.Generic;

int failed = 0;

failed += CheckAll("", 0, true, "", "");
failed += CheckAll("\u00A0 \u00A0", 0, true, "", "\u00A0 \u00A0\u00A0 \u00A0");
failed += CheckAll(" a\u00A0 b ", 2, false, "A. B.", " a\u00A0 b  a\u00A0 b ");
failed += CheckAll("А роза упала на лапу Азора", 6, true, "А. Р. У. Н. Л. А.",
    "А роза упала на лапу АзораА роза упала на лапу Азора");
failed += CheckAll("Ахметов Ерлан", 2, false, "А. Е.", "Ахметов ЕрланАхметов Ерлан");

const string fullName = "Ахметов Ерлан Серикұлы";
failed += Check("Initials", fullName, "А. Е. С.", TextTools.Initials(fullName));

return failed == 0 ? 0 : 1;

static int CheckAll(string input, int words, bool palindrome, string initials, string repeated)
{
    int failed = 0;
    failed += Check("CountWords", input, words, TextTools.CountWords(input));
    failed += Check("IsPalindrome", input, palindrome, TextTools.IsPalindrome(input));
    failed += Check("Initials", input, initials, TextTools.Initials(input));
    failed += Check("Repeat (n = 2)", input, repeated, TextTools.Repeat(input, 2));
    Console.WriteLine();
    return failed;
}

static int Check<T>(string method, string input, T expected, T actual)
{
    bool ok = EqualityComparer<T>.Default.Equals(expected, actual);
    Console.WriteLine($"{method} | вход {Show(input)} | ожидалось {Show(expected)} | получено {Show(actual)} | {(ok ? "OK" : "FAIL")}");
    return ok ? 0 : 1;
}

static string Show(object? value)
{
    if (value is string text)
        return "\"" + text.Replace("\u00A0", "\\u00A0") + "\"";

    return value?.ToString() ?? "";
}
