namespace Kalender._02;

public static class Oppgave02
{
    private const string Alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅabcdefghijklmnopqrstuvwxyzæøå";

    public static void Solve()
    {
        var linjer = File.ReadAllLines("02/logg.txt");
        var teller = -1;
        var result = string.Empty;
        foreach (var linje in linjer)
        {
            var chars = linje.ToCharArray();
            var output = string.Empty;
            foreach (var c in chars)
            {
                output += RotateChar(c, teller);
            }

            result += output;
            teller--;
        }
        
        Console.WriteLine("02 - " + result);
    }

    private static char RotateChar(char c, int rotateBy)
    {
        var alfaArray = Alfabet.ToCharArray();

        var index = alfaArray.IndexOf(c);
        if (index == 0)
        {
            index += alfaArray.Length;
        }

        var dekodet =  alfaArray[index + rotateBy];
        return dekodet;
    }
    
}