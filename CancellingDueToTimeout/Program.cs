using System;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace CancellingDueToTimeout
{
    class Program
    {
        static async Task IssueTimeout()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            cts.CancelAfter(TimeSpan.FromSeconds(5));
            await Task.Delay(TimeSpan.FromSeconds(10), token);

            WriteLine("I've managed to finish my work");
        }

        static async Task Main(string[] args)
        {
            IssueTimeout();
            ReadKey();
        }
    }
}
