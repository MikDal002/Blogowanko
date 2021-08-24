using System;
using System.Threading.Tasks;

namespace asynclocks
{
    partial class Program
    {
        static void Start(string taskName, int noOfTasks, Func<Task> test)
        {
            Console.WriteLine($"### {taskName} example with {noOfTasks} tasks start ###");
            var tasks = new Task[noOfTasks];
            for (int i = 0; i < noOfTasks; i++)
            {
                tasks[i] = Task.Run(async () => await test());
            }
            Task.WaitAll(tasks);
        }
    }
}
