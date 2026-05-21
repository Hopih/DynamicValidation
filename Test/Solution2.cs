namespace Test;

public class Solution2
{
    public void BuildReport(string salesFile, string errorsFile, string clientsFile)
    {
        int totalSales = 0;
        int errorCount = 0;
        int uniqueClients = 0;
        
        CancellationTokenSource cancellationToken = new CancellationTokenSource();
        CancellationToken token = cancellationToken.Token;
        object locker = new object();

        Task t1 = new Task(() =>
        {
            using (StreamReader r = new StreamReader(salesFile))
            {
                while (!r.EndOfStream)
                {
                    string line = r.ReadLine();
                    int number = int.Parse(line);

                    lock (locker)
                    {
                        totalSales += number;
                    }
                }
            }
        },token);
    }
}