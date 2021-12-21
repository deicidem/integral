using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Integral
{
    public class Calc2
    {
        public TaskFactory Factory { get; set; }
        public double Res = 0;
        public Calc2()
        {
            Factory = new TaskFactory();
        }

        public double integralFunction(double x)
        {
            return Math.Sqrt(x);
        }
        
        public void FindIntegral(double start, double end, double e)
        {
            double h = (end - start) / 2;
            List<Task> locTasks = new List<Task>();
            locTasks.Add(Factory.StartNew(() =>
            {
                var x = start;
                var val = h * integralFunction(x);
                if (h <= e) Res += val;
                else  locTasks.Add(Factory.StartNew(() => FindIntegral(x, x + h, e)));

            }));
            locTasks.Add(Factory.StartNew(() =>
            {
                var x = start + h;
                var val = h * integralFunction(x);
                if (h <= e) Res += val;
                else  locTasks.Add(Factory.StartNew(() => FindIntegral(x, x + h, e)));
            }));
            Task.WaitAll(locTasks.ToArray());
        }

        public double Start(double start, double end, double e)
        {
            Res = 0;
            FindIntegral(start, end, e);
            return Res;
        }
    }
}