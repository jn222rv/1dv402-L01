using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lonerevision
{
    public static class MyExtension
    {
        public static int Dispersion(this int[] source)
        {
            int number = source.Max() - source.Min();

            return number;
        }
        public static int Median(this int[] source)
        {
            int[] arr = source.OrderBy(a => a).ToArray();

            int number = arr.Length % 2;

            if (number == 0)
            {
                return (int)Math.Round(((arr[arr.Length / 2] + arr[(arr.Length / 2) - 1]) / (double)2));
            }
            else
            {
                return arr[(int)Math.Floor(arr.Length / (double)2)];
            }
        }
    }
}
