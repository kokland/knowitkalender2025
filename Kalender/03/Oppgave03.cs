namespace Kalender._03;

public static class Oppgave03
{
    public static void Solve()
    {
        var linjer = File.ReadAllLines("03/input.txt");

        var elementer = LastElementer(linjer)
            .OrderBy(a => a.TotalScore)
            .ToList();

        var all = elementer.Take(3)
            .Concat(elementer.TakeLast(3))
            .OrderByDescending(b => b.TotalScore)
            .Select(b => b.StringValue)
            .ToList();
        
        Console.WriteLine($"{nameof(Oppgave03)}: {string.Join(",", all)}");
    }

    private static List<Element> LastElementer(string[] linjer)
    {
        return linjer.Skip(1)
            .Select(line => line.Split(","))
            .Select(line => new Element()
            {
                Navn = line[0],
                Snill = int.Parse(line[1]),
                Slem = int.Parse(line[2]),
                Pepperkaker = int.Parse(line[3])
            }).ToList();
    }
}

public class Element
{
    public string? Navn { get; set; }
    public int Snill { get; set; }
    public int Slem { get; set; }
    public int Pepperkaker { get; set; }
    public int TotalScore => Snill * 50 - Slem * 25 + Pepperkaker * 15;
    public string StringValue => $"{Navn} {TotalScore}";
}