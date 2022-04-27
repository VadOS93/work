using System;

namespace Task
{
    /// <summary>
    /// Main program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Calculates the task.
        /// </summary>
        /// <param name="args">console call params.</param>
        public static void Main(string[] args)
        {
            int[] a = new int[20];

            Console.WriteLine("Please insert minValue and maxValue of array elements: ");
            int minValue = Convert.ToInt32(Console.ReadLine());
            int maxValue = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Now the array a looks like: ");

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = new Random().Next(minValue, maxValue);
                Console.Write(a[i] + " ");
            }

            Console.WriteLine();

            int[] b = new int[20];

            Console.WriteLine("Array b looks like following: ");

            for (int i = 0; i < b.Length; i++)
            {
                if (a[i] <= 888)
                {
                    b[i] = a[i];
                }
                else
                {
                    b[i] = 0;
                }

                Console.Write(b[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Sorted array b now looks in the following way: ");

            /*Array.Sort(B);
            Array.Reverse(B);
           */

            int temp = 0;
            for (int i = 0; i < b.Length - 1; i++)
            {
                for (int j = i + 1; j < b.Length; j++)
                {
                    if (b[i] < b[j])
                    {
                        temp = b[i];
                        b[i] = b[j];
                        b[j] = temp;
                    }
                }
            }

            for (int i = 0; i < b.Length; i++)
            {
                Console.Write(b[i] + " ");
            }
        }
    }
}
