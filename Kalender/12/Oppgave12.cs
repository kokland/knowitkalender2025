using System.Text.RegularExpressions;

namespace Kalender._12;

public static class Oppgave12
{
    public static void Solve()
    {
        var data = File.ReadAllLines("12/input.txt");
        const string Bamse = "01001010";
        const string Togsett = "01000010";
        // const string Slede = "01010010";
        
        var forrige = "";
        var antallBamser = 0;
        var antallSleder = 0;

        var joinedString = string.Join("", data);
        var regexPattern = Togsett + Bamse;
        var matches = Regex.Count(joinedString, regexPattern);
        Console.WriteLine(matches);

        var sisteTogProdusert = data.LastIndexOf(Togsett);
        for (var i = sisteTogProdusert; i < data.Length; i++)
        {
            if ( i <= sisteTogProdusert) continue;

            if (data[i] == Bamse)
            {
                antallBamser++;
            }
        }
        
        // foreach (var line in data)
        // {
        //     if (line is Bamse)
        //     {
        //         if (forrige is Togsett)
        //         {
        //             // her er forrige et togsett, så nåværende er en Bamse
        //             Console.WriteLine("Bamse");
        //             forrige = Bamse;
        //             antallBamser++;    
        //             continue;
        //         }
        //         else
        //         {
        //             // her er forrige ikke togsett, så nåværende er en Slede
        //             Console.WriteLine("Slede");
        //             forrige = "slede";
        //             antallSleder++;
        //             continue;    
        //         }
        //     }
        //     
        //     forrige = line;
        // }

        Console.WriteLine("Antall bamser: " + antallBamser);
        Console.WriteLine("Antall togsett: " + antallSleder);
        
        Console.WriteLine("Antall distincte koder: " + data.Distinct().Count());
    }
}