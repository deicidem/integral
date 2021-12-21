using System;
using System.Threading;
using System.Threading.Tasks;

namespace Integral
{
    class Program
    {
        static void Main(string[] args)
        {
            // var calc = new Calc();
            // var startTimeAsync = DateTime.Now;
            // var t = Task.Run(() => calc.FindIntegral(0, 4, 0.0001)).ContinueWith((e) =>
            // {
            //     TimeSpan ts = DateTime.Now - startTimeAsync;
            //     Console.WriteLine(e.Result);
            //     Console.WriteLine("Parallel time needed: " + ts.TotalMilliseconds);
            // });
            // Task.WaitAll(t);
            // double res = 0;
            // var startTimeSync = DateTime.Now;
            // for (double i = 0; i < 4; i += 0.0001 )
            // {
            //     res += 0.0001 * Math.Sqrt(i);
            // }
            //
            // var ts = DateTime.Now - startTimeSync;
            // Console.WriteLine(res);
            // Console.WriteLine("Sync time needed: " + ts.TotalMilliseconds);
            var calc = new Calc2();
            Console.WriteLine(calc.Start(0, 4, 0.0001));
        }
        
    }
}