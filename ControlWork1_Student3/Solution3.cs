namespace ControlWork1_Student3;

public class Solution3
{
    public static void Solve()
    {
        List<Expense> lst = new List<Expense>();
        using (StreamReader report = new StreamReader("reports.txt"))
        {
            while (!report.EndOfStream)
            {
                string line = report.ReadLine();
                string [] columns = line.Split(';');
                Expense exp = new Expense()
                {
                    Category = columns[0],
                    Amount = int.Parse(columns[1])
                };
                lst.Add(exp);
            }
        }
        var result = lst.GroupBy(x => x.Category).Select(x => new { Category = x.Key, Amount = x.Count() , sum = x.Sum(y => y.Amount) });
        using (StreamWriter output = new StreamWriter("output.txt"))
        {
            foreach (var item in result)
            {
                output.WriteLine($"{item.Category}: count={item.Amount}, sum={item.sum}");
            }
        }
    }
}