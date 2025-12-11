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
            
            
            Console.WriteLine($"Navn: {maskin.Navn}, Temperatur: {maskin.Temperatur}, Vann: {maskin.Vann}, Kullsyre: {maskin.Kullsyre}, Produsert: {maskin.Summary()}");
            produsert.TryAdd(maskin.Navn, 0);
            produsert[maskin.Navn] += maskin.Summary();
        }

        var størsteProdusert = produsert.OrderByDescending(p => p.Value);
        var størsteProduserendeMaskin = størsteProdusert.First().Key;
        var total = produsert.Sum(p => p.Value);
        
        
        
        
        Console.WriteLine($"{nameof(Oppgave10)}: {total} {størsteProduserendeMaskin}");
    }
}

public class BrusProduksjon
{
    public string Navn { get; set; }
    public int Temperatur { get; set; }
    public int Vann { get; set; }
    public int Kullsyre { get; set; }

    public BrusProduksjon(string input)
    {
        var parts = input.Split(',');
        Navn = parts[0].Replace("Maskin", "").Trim();
        Temperatur = ParseParameter(parts[1], "temperatur", "C");
        Vann = ParseParameter(parts[2], "vann", "L");
        Kullsyre = ParseParameter(parts[3], "kullsyre", "L");
    }

    private static int ParseParameter(string field, string prefix, string suffix)
    {
        var value = field.Replace(prefix, "")
            .Replace(suffix, "")
            .Trim();
        return int.Parse(value);
    }

    public bool IsProductionReady()
    {
        if (Vann is < 400 or > 1500)
        {
            return false;
        }

        if (Kullsyre is < 300 or > 500)
        {
            return false;
        }

        if (Temperatur is < 95 or > 105)
        {
            return false;
        }

        return true;
    }

    public int Summary()
    {
        if (!IsProductionReady()) return 0;
        
        var produsert = (Vann - 100) + (Kullsyre / 10);
        double fratrekk = 0;
        if (Temperatur >= 100)
        {
            fratrekk = produsert / 40;
            fratrekk = Math.Floor(fratrekk);
        }

        return produsert - Convert.ToInt32(fratrekk);
    }
}