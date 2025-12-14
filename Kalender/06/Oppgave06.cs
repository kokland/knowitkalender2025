using System.Numerics;

namespace Kalender._06;

public static class Oppgave06
{
    public static void Solve()
    {
        var data = File.ReadAllText("06/perfeksjonsruten.txt");

        var ruter = data.Split(";");
        var maps = new List<MapDefinition>();
        foreach (var rute in ruter)
        {
            maps.Add(new MapDefinition(rute));
        }

        var totalDistance = maps.Select(s => s.DistanceTravelled).Sum();
        Console.WriteLine($"Total distance: {totalDistance}");
        // foreach (var map in maps)
        // {
        //     Console.WriteLine($"Antall steg: {map.DistanceTravelled}");
        // }
    }
}

public class MapDefinition
{
    public char[][] Kart { get; set; }
    public Vector2 Start { get; set; }
    public Vector2 Stopp { get; set; }
    public List<Vector2> Path { get; set; }
    public int DistanceTravelled => Path.Count == 0 ? 0 : Path.Count - 1;


    public MapDefinition(string input)
    {
        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        Kart = lines.Select(line => line.ToCharArray()).ToArray();

        for (var i = 0; i < Kart.Length; i++)
        {
            for (var j = 0; j < Kart[i].Length; j++)
            {
                if (Kart[i][j] == 'S')
                {
                    Start = new Vector2(i, j);
                }

                if (Kart[i][j] == '*')
                {
                    Stopp = new Vector2(i, j);
                }
            }
        }

        Path = FindPath();
    }


    private List<Vector2> FindPath()
    {
        var queue = new Queue<(Vector2 pos, List<Vector2> path)>();
        var visited = new HashSet<(int, int)>();

        queue.Enqueue((Start, new List<Vector2> { Start }));
        visited.Add(((int)Start.X, (int)Start.Y));

        Vector2[] directions = { new(0, 1), new(0, -1), new(1, 0), new(-1, 0) };

        while (queue.Count > 0)
        {
            var (pos, path) = queue.Dequeue();

            if (pos == Stopp)
                return path;

            foreach (var dir in directions)
            {
                var newPos = pos + dir;
                var x = (int)newPos.X;
                var y = (int)newPos.Y;

                if (x >= 0 && x < Kart.Length && y >= 0 && y < Kart[0].Length &&
                    !visited.Contains((x, y)) && Kart[x][y] != '#')
                {
                    visited.Add((x, y));
                    var newPath = new List<Vector2>(path) { newPos };
                    queue.Enqueue((newPos, newPath));
                }
            }
        }

        return new List<Vector2>();
    }
}
