using System.Security.Cryptography;

namespace Kalender._04;

public class Oppgave04
{
    private const int StandardEnergi = 5;

    public static void Solve()
    {
        var data = File.ReadAllText("04/input.txt");

        var energi = 3000;

        for (var i = 0; i < data.Length; i++)
        {
            if (energi <= 0)
            {
                continue;
            }

            var current = data[i];
            switch (current)
            {
                case 'S':
                    energi -= StandardEnergi;
                    break;
                case 'B':
                    energi -= StandardEnergi * 2;
                    break;
                case 'D':
                    energi -= StandardEnergi * 3;
                    break;
                case 'I':
                    break;
                case 'P':
                    if (i <= 1) continue;

                    var bruktEnergi = BrukteEnergiForrigeTo(data[i - 1], data[i - 2]);
                    energi += bruktEnergi;
                    break;
            }


            Console.WriteLine("Energi igjen etter etappe nr " + i + " -> " + current + ": " + energi);
        }
    }

    private static int BrukteEnergiForrigeTo(char a, char b)
    {
        var sum = 0;
        sum += BeregnEnergiForbruk(a);
        sum += BeregnEnergiForbruk(b);
        return sum;
    }

    private static int BeregnEnergiForbruk(char x)
    {
        return x switch
        {
            'S' => StandardEnergi,
            'B' => StandardEnergi * 2,
            'D' => StandardEnergi * 3,
            _ => 0
        };
    }
}