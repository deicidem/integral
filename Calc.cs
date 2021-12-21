using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Integral
{
    public class Calc
    {
        public TaskFactory Factory { get; set; }
        public Calc()
        {
            Factory = new TaskFactory();
        }

        public double integralFunction(double x)
        {
            return Math.Sqrt(x);
        }

        public double RunTask(double start, double h, double e)
        {
            var x = start;
            var val = h * integralFunction(x);
            if (h <= e) return val;
            return Factory.StartNew(() => FindIntegral(x, x + h, e)).Result;
        }
        public double FindIntegral(double start, double end, double e)
        {
            double res = 0;
            double h = (end - start) / 2;
            res += Factory.StartNew(() => RunTask(start, h, e)).Result;
            res += Factory.StartNew(() => RunTask(start + h, h, e)).Result;
            return res;
        }
    }
}