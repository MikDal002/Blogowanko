using System;
using System.Threading;
using System.Threading.Tasks;

class CriticalSectionForFlag
{
    private object _locker = new object();
    private bool isThereAnotherThread = false;
    public async Task SectionWithFlag(string name)
    {
        var doIhaveLock = false;
        try
        {
            lock (_locker)
            {
                if (!isThereAnotherThread)
                {
                    doIhaveLock = true;
                    isThereAnotherThread = true;
                }
            }

            if (doIhaveLock)
            {
                Console.WriteLine($"With lock {name}!");
                await Task.Delay(TimeSpan.FromSeconds(10));
            }
            else
            {
                Console.WriteLine($"Without lock {name}!");
                // await Task.Delay(TimeSpan.FromSeconds(5)); // <1>
            }
        }
        finally
        {
            lock (_locker)
            {
                if (doIhaveLock)
                    isThereAnotherThread = false;
            }
        }

        Console.WriteLine($"Exiting... {name}");
    }
}
