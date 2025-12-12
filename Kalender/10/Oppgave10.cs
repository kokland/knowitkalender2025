namespace Kalender._10;

public static class Oppgave10
{
    public static void Solve()
    {
        var data = File.ReadAllLines("10/input.txt");
        var produsert = new Dictionary<string, int>();

        foreach (var line in data)
        {
            var maskin = new BrusProduksjon(line);
            if (!maskin.IsProductionReady()) continue;
            produsert.TryAdd(maskin.Navn, 0);
            produsert[maskin.Navn] += maskin.KalkulerProduksjon();
        }

        var størsteProdusert = produsert.OrderByDescending(p => p.Value);
        var størsteProduserendeMaskin = størsteProdusert.First().Key;
        var total = produsert.Sum(p => p.Value);
        
        Console.WriteLine($"{nameof(Oppgave10)}: {total} {størsteProduserendeMaskin}");
    }
}