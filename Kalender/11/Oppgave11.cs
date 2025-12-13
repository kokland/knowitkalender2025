namespace Kalender._11;

public class Oppgave11
{
    public static void Solve()
    {
        var data = File.ReadAllLines("11/input.txt");
        // data = ["20", "dukke,5,30", "lego,10,50", "sokker,8,40", "klementin,4,10"];
        var maksGlede = MaksGlede(data);
        var maksFractional = MaxJoyFractional(int.Parse(data[0]), LastPakker(data));

        Console.WriteLine($"{nameof(Oppgave11)}: {maksGlede} og {maksFractional}");
    }

    private static double MaxJoyFractional(int capacity, IEnumerable<Pakke> pakker)
    {
        var sorted = pakker
            .OrderByDescending(p => (double)p.Glede / p.Vekt)
            .ToList();

        double joy = 0;
        var remaining = capacity;

        foreach (var p in sorted)
        {
            if (remaining == 0) break;
            if (p.Vekt <= remaining)
            {
                joy += p.Glede;
                remaining -= p.Vekt;
            }
            else
            {
                var fraction = (double)remaining / p.Vekt;
                joy += p.Glede * fraction;
                remaining = 0;
            }
        }

        return joy;
    }

    private static int MaksGlede(string[] data)
    {
        var capacity = int.Parse(data[0]);
        var pakker = LastPakker(data);
        
        var dp = new int[capacity + 1];
        foreach (var pakke in pakker)
        {
            for (var c = capacity; c >= pakke.Vekt; c--)
            {
                dp[c] = Math.Max(dp[c], dp[c - pakke.Vekt] + pakke.Glede);
            }
        }

        return dp[capacity];
    }

    private static List<Pakke> LastPakker(string[] data)
    {
        var x = data
            .Skip(1)
            .Select(pakke => pakke.Split(","))
            .Select(parts => new Pakke()
            {
                Navn = parts[0], 
                Vekt = int.Parse(parts[1]), 
                Glede = int.Parse(parts[2])
            })
            .OrderBy(x => x.Vekt).ToList();
        return x;
    }
}

public class Pakke
{
    public int Vekt { get; set; }
    public int Glede { get; set; }
    public string Navn { get; set; }
}