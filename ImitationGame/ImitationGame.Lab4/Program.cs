using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitationGame.Lab4
{

    /// <summary>
    /// For task 1
    /// f(t) = k*sin(t) t in [0,a]
    /// F(x) = k(1-cosx)
    /// x = arccos(1 - y/k)
    /// y in [(1-Pi/2)*k  , (1 - cosa)*k]
    /// e(alpha) = arccos(1-alpha/k)
    /// ----------------------------------------
    /// 
    /// f(t) = k*sin(t + a) in [-a, 0]
    /// </summary>


    class Program
    {


        static double FunctionE1(double alpha, double k)
        {
            return Math.Acos(1 - alpha / k);
        }

        static void Main(string[] args)
        {
            var t = FunctionE1(1, 5);
            var t1 = FunctionE1(1.01, 5);
            var t2 = FunctionE1(1.02, 5);
            var t3 = FunctionE1(1.03, 5);
            var t4 = FunctionE1(1.04, 5);
            var t5 = FunctionE1(1.05, 5);
            var t6 = FunctionE1(1.06, 5);

        }
    }
}
