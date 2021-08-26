using System;
using System.Threading.Tasks;

namespace asynclocks
{
    partial class Program
    {
        static void Main(string[] args)
        {
            // var monitor = new MonitorExample();
            // Start("Monitor", 2, monitor.MonitorNotProtected );
 
            // var monitor2 = new MonitorExample();
            // Start("Monitor", 20, monitor2.MonitorNotProtected);
 
            var critical2 = new CriticalSectionForFlag();
            Start("Critical section with flag", 2, critical2.SectionWithFlag);

            var critical10 = new CriticalSectionForFlag();
            Start("Critical section with flag", 20, critical10.SectionWithFlag);

            var sem2 = new AsyncSemaphore();
            Start("Critical section with flag", 2, sem2.SemaphoreAsync);
        }

        // private object _locker = new object();
        // async Task NotWorkingLock() 
        // {
        //     lock(_locker) {
        //         await Task.Delay(TimeSpan.FromSeconds(5));
        //     }
        // }
    }
}
