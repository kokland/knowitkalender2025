namespace Kalender._10;

public class BrusProduksjon
{
    public string Navn { get; set; }
    private int Temperatur { get; set; }
    private int Vann { get; set; }
    private int Kullsyre { get; set; }

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

    public int KalkulerProduksjon()
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