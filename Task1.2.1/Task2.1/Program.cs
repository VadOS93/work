 using System;

namespace Task2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert the array size: ");
            int N = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[N];
            int rangeCount = 0;

            Console.WriteLine("Now the array looks like: ");

            foreach (int i in array)
            {
                array[i] = new Random().Next(-300, 300);
                if (array[i] > -100 & array[i] < 100)
                    rangeCount++;
                Console.WriteLine(array[i]);
            }

            switch (rangeCount)
            {
                case 0:  Console.WriteLine("There are no numbers satisfying the given range");
                    break;
                case 1:  Console.WriteLine("There is " + rangeCount + " number which satisfies the given range");
                    break;
                default: Console.WriteLine("There are " + rangeCount + " numbers which satisfy the given range");
                    break;
            }
        }
    }
}
