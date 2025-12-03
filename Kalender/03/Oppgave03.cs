namespace Kalender._03;

public static class Oppgave03
{
    public static void Solve()
    {
        var linjer = File.ReadAllLines("03/input.txt");

        var elementer = LastElementer(linjer)
            .OrderBy(a => a.TotalScore)
            .ToList();
        
        var top3 = elementer.Take(3);
        var bottom3 = elementer.TakeLast(3); 
        var all = top3.Concat(bottom3)
            .OrderByDescending(b => b.TotalScore)
            .Select(b => b.StringValue)
            .ToList();
        
        Console.WriteLine(string.Join(",", all));
    }

    private static List<Element> LastElementer(string[] linjer)
    {
        var elementer = new List<Element>();

        for (var i = 1; i < linjer.Length; i++)
        {
            var parts = linjer[i].Split(',');
            var element = new Element()
            {
                Navn = parts[0],
                Snill = int.Parse(parts[1]),
                Slem = int.Parse(parts[2]),
                Pepperkaker = int.Parse(parts[3])
            };
            elementer.Add(element);
        }

        return elementer;
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