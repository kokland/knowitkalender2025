// See https://aka.ms/new-console-template for more information

using System.Globalization;
using Kalender._01;
using Kalender._02;


Console.WriteLine("Hvilken oppgave vil du kjøre? [01-24]");
var input = Console.ReadLine();
var oppgaveNummer = int.Parse(input);
if (oppgaveNummer is < 1 or > 24)
{
    Console.WriteLine("Ugyldig oppgavenummer");
    return;
}

switch (oppgaveNummer)
{
    case 1:
        Oppgave01.Solve();
        break;
    
    case 2:
        Oppgave02.Solve();
        break;
    default:
        Console.WriteLine("Ugyldig oppgave");
        break;
}
