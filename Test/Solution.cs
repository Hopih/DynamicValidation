namespace Test;

public class Solution
{
    public void ProcessData(int[] orders, bool[] usersEmailConfirmed, int[] productStocks)
    {
        int badOrders = 0;
        int badUsers = 0;
        int badProducts = 0;

        object locker = new object();
        CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken token = cts.Token;

        Task t1 = new Task(() =>
        {
            foreach (var num in orders)
            {
                if (token.IsCancellationRequested) break;
                if (num > 10000)
                {
                    lock (locker)
                    {
                        badOrders++;
                        if (badOrders > 100) cts.Cancel();
                    }
                }
            }
        }, token);
        Task t2 = new Task(() =>
        {
            foreach (var num in usersEmailConfirmed)
            {
                if (token.IsCancellationRequested) break;
                if (!num)
                {
                    lock (locker)
                    {
                        badUsers++;
                        if (badUsers > 100) cts.Cancel();
                    }
                }
            }
        }, token);

        Task t3 = new Task(() =>
        {
            foreach (var num in productStocks)
            {
                if (token.IsCancellationRequested) break;
                if (num == 0)
                {
                    lock (locker)
                    {
                        badProducts++;
                        if (badProducts > 100) cts.Cancel();
                    }
                }
            }
        }, token);

        t1.Start();
        t2.Start();
        t3.Start();

        Task.WaitAll(t1, t2, t3);

        Console.WriteLine($"Заказов > 10000: {badOrders}");
        Console.WriteLine($"Пользователей без email: {badUsers}");
        Console.WriteLine($"Товаров с остатком 0: {badProducts}");
    }
}