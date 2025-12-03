using System.Text;

namespace Kalender._01;

public class Oppgave01
{
    // I loggen finnes 3 typer kommandoer:
    // ADD <pakke>- Ordre om ny gave som skal produseres
    // PROCESS - Den gaveordren som har ventet lengst blir produsert. Den første bokstaven i gaven er en del av nøkkelen. Hvis ingen gaver er i kø, legges det til en X
    // COUNT - Julegavemaskinen viser hvor mange gaver som venter på å bli produsert. Det sist sifferet i dette tallet er del av nøkkelen.

    public static void Solve()
    {
        var logg = File.ReadAllLines("01/logg.txt");

        // var gaver = new List<string>();
        var gaver = new Queue<string>();
        var løsning = new StringBuilder();

        foreach (var linje in logg)
        {
            if (linje.StartsWith("ADD"))
            {
                var gave = linje.Split(" ").Last();
                gaver.Enqueue(gave);
                continue;
            }

            if (linje == "COUNT")
            {
                løsning.Append(gaver.Count % 10);
                continue;
            }

            if (linje == "PROCESS")
            {
                var item = gaver.TryDequeue(out var gave) ? gave[0] : 'X';
                løsning.Append(item);
            }
        }

        Console.WriteLine($"{nameof(Oppgave01)}: {løsning}");
    }
}