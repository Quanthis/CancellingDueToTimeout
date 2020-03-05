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

            cts.CancelAfter(TimeSpan.FromSeconds(2));
            await Task.Delay(TimeSpan.FromSeconds(5), token);

            WriteLine("I've managed to finish my work");                //never reached
        }

        static async Task Main(string[] args)
        {
            IssueTimeout();
            ReadKey();
        }
    }
}
