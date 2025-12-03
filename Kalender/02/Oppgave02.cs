namespace Kalender._02;

public static class Oppgave02
{
    private const string Alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅabcdefghijklmnopqrstuvwxyzæøå";

    public static void Solve()
    {
        var linjer = File.ReadAllLines("02/logg.txt");

        var result = linjer.SelectMany((l, index) =>
            l.Select(c => RotateChar(c, -(index + 1)))
        );

        Console.WriteLine($"{nameof(Oppgave02)}: {string.Concat(result)}");
    }

    private static char RotateChar(char c, int rotateBy)
    {
        var index = Alfabet.IndexOf(c);
        if (index == 0)
        {
            index += Alfabet.Length;
        }

        var dekodet = Alfabet[index + rotateBy];
        return dekodet;
    }
}