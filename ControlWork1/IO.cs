namespace ControlWork1;
using System.IO;
using System.Linq;
public class IO
{
    public void Solve()
    {
        List<string[]> LogEntry = new List<string[]>();
        using (StreamReader file = new StreamReader("logs.txt"))
        {
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                string[] words = line.Split(';');
                if ((words.Where(x => x==words[2] && int.Parse(words[2]) > 10)).Count() > 0)
                {
                    LogEntry.Add(words); 
                } 
            }
        }

        var res = LogEntry.GroupBy(x => x[0]).Select(g => new
        {
            Name = g.Key,
            Time = g.Sum(x => int.Parse(x[2])),
            TotalCount = g.Count()
        });
        using (StreamWriter file = new StreamWriter("results.txt"))
        {
            foreach (var entry in res)
            {
                file.WriteLine($"{entry.Name};{entry.Time};{entry.TotalCount}");
            }
        }
    }
}