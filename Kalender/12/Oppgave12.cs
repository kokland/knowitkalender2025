namespace Kalender._12;

public class Oppgave12
{
    public static void Solve()
    {
        var data = File.ReadAllLines("12/input.txt");
        // data = ["20", "dukke,5,30", "lego,10,50", "sokker,8,40", "klementin,4,10"];
        var maksGlede = MaksGlede(data);

        Console.WriteLine($"{nameof(Oppgave12)}: {maksGlede}");
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
        return data
            .Skip(1)
            .Select(pakke => pakke.Split(","))
            .Select(parts => new Pakke()
            {
                Navn = parts[0], 
                Vekt = int.Parse(parts[1]), 
                Glede = int.Parse(parts[2])
            }).ToList();
    }
}

public class Pakke
{
    public int Vekt { get; set; }
    public int Glede { get; set; }
    public string Navn { get; set; }
}