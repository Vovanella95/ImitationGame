using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitationGame.Lab2
{
    class Program
    {
        // Variant 8

        static IEnumerable<double> MultiplicatedNumberSequence(int n, double a, double beta, double m)
        {
            for (int i = 1; i <= n; i++)
            {
                a = (beta * a) % m;
                yield return a / m;
            }
        }

        static IEnumerable<double> LinearMethod(int n, int p, double[] a, double[] beta, double c, double m)
        {
            for (int i = 1; i <= n; i++)
            {
                var a1 = (beta.Select((w, j) => w * a[p - j - 1]).Sum() + c) % m;
                yield return a1 / m;

                for (int j = 0; j < p - 1; j++)
                {
                    a[j] = a[j + 1];
                }
                a[p - 1] = a1;
            }
        }

        static IEnumerable<double> SquareMethod(int n, double a0, double gamma, double beta, double c, double m)
        {
            
            for (int i = 1; i <= n; i++)
            {
                a0 = (gamma * a0 * a0 + beta * a0 + c) % m;
                yield return a0 / m;
            }
            
        }


        static void Main(string[] args)
        {
            var sequence1 = MultiplicatedNumberSequence(10, 65539, 203, 109).ToArray();
            var sequence2 = LinearMethod(10, 5, new double[] { 1, 2, 3, 4, 5 }, new double[] { 13, 13, 13, 13, 13 }, 0, 109).ToArray();
            var sequence3 = SquareMethod(10, 54321, 26, 3, 11, Math.Pow(2, 31) - 1).ToArray();
        }
    }
}
