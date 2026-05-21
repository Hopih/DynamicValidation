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
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }
                    string line = r.ReadLine();
                    int number = int.Parse(line);

                    if (number < 0)
                    {
                        cancellationToken.Cancel();
                    }
                    lock (locker)
                    {
                        totalSales += number;
                    }
                }
            }
        },token);

        Task t2 = new Task(() =>
        {
            using (StreamReader r = new StreamReader(errorsFile))
            {
                while (!r.EndOfStream)
                {
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }
                    string line = r.ReadLine();
                    if (line == null)
                    {
                        cancellationToken.Cancel();
                    }
                    
                    if (line == "ERROR")
                    {
                        lock (locker)
                        {
                            errorCount += 1;
                        }
                    }
                }
            }
        },token);
        
        HashSet<string> table = new HashSet<string>();

        Task t3 = new Task(() =>
            {
                using (StreamReader r = new StreamReader(clientsFile))
                {
                    while (!r.EndOfStream)
                    {
                        if (token.IsCancellationRequested)
                        {
                            break;
                        }
                        string line = r.ReadLine();
                        if (line == null || line == "CRITICAL")
                        {
                            cancellationToken.Cancel();
                        } 
                        lock (locker)
                        {
                            if (table.Contains(line))
                            {
                                continue;
                            }
                            else
                            {
                                table.Add(line);
                                uniqueClients++;
                            }
                        }
                    }
                }
            } , token
        );
        t1.Start();
        t2.Start();
        t3.Start();
    }       
}