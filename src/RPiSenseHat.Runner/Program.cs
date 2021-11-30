using System;
using System.Threading;
using System.Threading.Tasks;

namespace RPiSenseHat.Runner
{
    static class Program
    {
        static void Main(string[] args)
        {
            var tokenSource = new CancellationTokenSource();

            Console.WriteLine("[HAT]: SenseHat Demo");
            
            var runTask = Task.Run(async () =>
            {
                await new Runner().RunAsync(tokenSource.Token);
            }, tokenSource.Token);


            Console.WriteLine($"[HAT]: Press any key to exit.");
            Console.ReadKey();

            tokenSource.Cancel();
            runTask.Wait();

            Console.WriteLine("[HAT]: End");
        }
    }
}