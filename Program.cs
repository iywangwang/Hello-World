using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double [] array = new double[10];
            InitArray(array);
            PrintArray(array);

            Console.WriteLine();
            double [] array2 = new double[5];
            System.Array.Copy(array, array2, 5);
            PrintArray(array2);
        }

        static void InitArray(double[] array)
        {
            double num = 10D;
            for (int i = 0; i < array.Length; i++, num++)
            {  
                array[i] = num;
            }
        }

        static void PrintArray(double[] array)
        {
            foreach (var item in array)
            {
                Console.Write("{0}\t", item);
                Console.WriteLine();
            }
        }
    }
}
