using System.Diagnostics;

namespace Kalender._04;

public class Oppgave04
{
    private static string? data;
    private static int etappe = 0;

    public static void Solve()
    {
        data = File.ReadAllText("04/input.txt");
        var energi = 3000;


        var prev1 = 0;
        var prev2 = 0;

        for (var i = 0; i < data.Length; i++)
        {
            var cost = data[i] switch
            {
                'S' => 5,
                'B' => 10,
                'D' => 15,
                'I' => 0,
                'P' => 0,
                _ => 0
            };

            if (cost > 0 && energi < cost)
            {
                break;
            }

            energi -= cost;

            if (data[i] == 'P')
            {
                energi += prev1 + prev2;
            }

            prev2 = prev1;
            prev1 = cost;

            etappe++;
        }

        Console.WriteLine($"{nameof(Oppgave04)}: {etappe * 10}");
    }
}