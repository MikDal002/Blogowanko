using System;
using System.Threading;
using System.Threading.Tasks;

namespace asynclocks
{
    partial class Program
    {
        static void Start(string taskName, int noOfTasks, Func<string,Task> test)
        {
            Console.WriteLine($"### {taskName} example with {noOfTasks} tasks start ###");
            var tasks = new Task[noOfTasks];
            for (int i = 0; i < noOfTasks; i++)
            {
                tasks[i] = Task.Run(async () => {
                    var thread = Thread.CurrentThread.ManagedThreadId;
                    var task = Task.CurrentId;
                    var name = $"({task}-{thread})";
                    await test(name);
                });
            }
            Task.WaitAll(tasks);
        }
    }
}
