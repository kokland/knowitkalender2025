using System.Text;
using System.Text.RegularExpressions;

namespace Kalender._09;

public class Oppgave09
{
    public static void Solve()
    {
        var input = File.ReadAllText("09/input.txt");

        var result = new List<char>();

        for (var i = 0; i < input.Length; i++)
        {
            // tall skal fjernes
            var current = input[i];
            if (IsNumeric(current))
            {
                continue;
            }

            // konsonanter skal tas vekk, med mindre de er omgitt av tall ved index -2 og +2
            if (IsConsonant(current))
            {
                if (i < 2) continue;
                if (i >= input.Length - 2) continue;

                if (!IsNumeric(input[i - 2]) || !IsNumeric(input[i + 2]))
                {
                    continue;
                }
            }

            result.Add(current);
        }

        Console.WriteLine($"{nameof(Oppgave09)}: {string.Join("", result)}");
    }

    private static bool IsConsonant(char current)
    {
        const string pattern = "[bcdfghjklmnpqrstvwxz]";
        var match = Regex.Match(current.ToString(), pattern, RegexOptions.IgnoreCase);
        return match.Success;
    }

    private static bool IsNumeric(char c)
    {
        var isNumeric = int.TryParse(c.ToString(), out _);
        return isNumeric;
    }

    private static bool IsVowel(char c)
    {
        var pattern = "[aeiouyæøå]";
        var match = Regex.Match(c.ToString(), pattern, RegexOptions.IgnoreCase);

        return match.Success;
    }
}