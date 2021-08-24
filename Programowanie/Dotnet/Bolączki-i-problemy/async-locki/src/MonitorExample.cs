using System;
using System.Threading;
using System.Threading.Tasks;

class MonitorExample
{
    private object _locker = new object();
    public async Task MonitorNotProtected()
    {
        var thread = Thread.CurrentThread.ManagedThreadId;
        var task = Task.CurrentId;
        var name = $"({task}-{thread})";

        bool lockTaken = false;
        Monitor.TryEnter(_locker, ref lockTaken);
        if (lockTaken)
        {
            try
            {
                Console.WriteLine($"With lock {name}!");
                await Task.Delay(TimeSpan.FromSeconds(10));
            }
            finally
            {
                Monitor.Exit(_locker);
            }
        }
        else
        {
            Console.WriteLine($"Without lock {name}!");
            await Task.Delay(TimeSpan.FromSeconds(5));  // <1>
        }
        Console.WriteLine($"Exiting... {name}");
    }
}