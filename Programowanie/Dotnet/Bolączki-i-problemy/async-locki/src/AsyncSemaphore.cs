using System;
using System.Threading;
using System.Threading.Tasks;

class AsyncSemaphore
{
    SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1);
    public async Task SemaphoreAsync(string name)
    {
        Console.WriteLine($"Before trying lock {name}!");
        await semaphoreSlim.WaitAsync();
        try
        {
            Console.WriteLine($"With lock {name}!");
            await Task.Delay(TimeSpan.FromSeconds(10));
        }
        finally
        {
            semaphoreSlim.Release();
        }

        Console.WriteLine($"Exiting... {name}");
    }
}
