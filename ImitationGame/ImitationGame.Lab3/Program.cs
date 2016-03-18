using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImitationGame.Lab3
{
    /// <summary>
    /// Из урны, в которой есть 100 шаров (из них один особенный) достают 10 случайных шаров.
    /// Какова вероятность того, что из 10 вытащенных шаров есть нужный. Аналитически получим:
    /// A - событие выпадания особенного шара в 10 шарах
    /// p(A) = 1/100 + (1/99)*(99/100) + (1/98)/(99/100)*(98/99) + ... + (1/91)*(99/100)*(98/99)*(97/98)*(96/97)*...*(91/92) = 1/100 + 1/100 + ... + 1/100 = 0.1
    /// </summary>




    class Program
    {
        // Вариант 8
        static bool MakeOneTest()
        {
            Box a = new Box();
            for (int i = 0; i < 10; i++)
            {
                if (a.GetRandomCard())
                {
                    return true;
                }
            }
            return false;
        }

        public static double SolveTaskNumericly()
        {
            int positiveCounter = 0;
            int count = (int)Math.Pow(10, 5);

            for (int i = 0; i < count; i++)
            {
                if (MakeOneTest())
                {
                    positiveCounter ++;
                }
                Thread.Sleep(1);
            }
            return ((double)positiveCounter) / count;
        }

        public static double SolveTaskAnalitical()
        {
            return 0.1;
        }


        static void Main(string[] args)
        {
            var roundedSolution = SolveTaskNumericly();
            var calculatedSolution = SolveTaskAnalitical();
        }
    }
}
