using System;

namespace ModuleOne
{
    /// <summary>
    /// Main program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Module task.
        /// </summary>
        /// <param name="args">My program.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Please put your array size:");
            string arraysize = Console.ReadLine();
            int n = int.Parse(arraysize);
            int minValue = 1;
            int maxValue = 26;
            int[] array = new int[n];
            int oddValues = 0;
            int evenValues = 0;
            Console.WriteLine("Initial array is: ");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Random().Next(minValue, maxValue);
                Console.Write(array[i] + " ");
                if (array[i] % 2 == 0)
                {
                    evenValues++;
                }
                else
                {
                    oddValues++;
                }
            }

            Console.WriteLine();
            object[] arrayOne = new object[evenValues];
            object[] arrayTwo = new object[oddValues];
            int arrayOneCounter = 0;
            int arrayTwoCounter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    arrayOne[arrayOneCounter] = array[i];
                    arrayOneCounter++;
                }
                else
                {
                    arrayTwo[arrayTwoCounter] = array[i];
                    arrayTwoCounter++;
                }
            }

            bool isupper;
            int upperCharsOne = 0;
            int upperCharsTwo = 0;
            Console.WriteLine();
            for (int i = 0; i < arrayOne.Length; i++)
            {
                switch (arrayOne[i])
                {
                    case 2:
                        arrayOne[i] = 'b';
                        break;
                    case 4:
                        arrayOne[i] = 'D';
                        break;
                    case 6:
                        arrayOne[i] = 'f';
                        break;
                    case 8:
                        arrayOne[i] = 'H';
                        break;
                    case 10:
                        arrayOne[i] = 'J';
                        break;
                    case 12:
                        arrayOne[i] = 'l';
                        break;
                    case 14:
                        arrayOne[i] = 'n';
                        break;
                    case 16:
                        arrayOne[i] = 'p';
                        break;
                    case 18:
                        arrayOne[i] = 'r';
                        break;
                    case 20:
                        arrayOne[i] = 't';
                        break;
                    case 22:
                        arrayOne[i] = 'v';
                        break;
                    case 24:
                        arrayOne[i] = 'x';
                        break;
                    case 26:
                        arrayOne[i] = 'z';
                        break;
                    default:
                        break;
                }

                isupper = char.IsUpper((char)arrayOne[i]);
                if (isupper == true)
                {
                    upperCharsOne++;
                }
            }

            for (int i = 0; i < arrayTwo.Length; i++)
            {
                switch (arrayTwo[i])
                {
                    case 1:
                        arrayTwo[i] = 'A';
                        break;
                    case 3:
                        arrayTwo[i] = 'c';
                        break;
                    case 5:
                        arrayTwo[i] = 'E';
                        break;
                    case 7:
                        arrayTwo[i] = 'g';
                        break;
                    case 9:
                        arrayTwo[i] = 'I';
                        break;
                    case 11:
                        arrayTwo[i] = 'k';
                        break;
                    case 13:
                        arrayTwo[i] = 'm';
                        break;
                    case 15:
                        arrayTwo[i] = 'o';
                        break;
                    case 17:
                        arrayTwo[i] = 'q';
                        break;
                    case 19:
                        arrayTwo[i] = 's';
                        break;
                    case 21:
                        arrayTwo[i] = 'u';
                        break;
                    case 23:
                        arrayTwo[i] = 'w';
                        break;
                    case 25:
                        arrayTwo[i] = 'y';
                        break;
                    default:
                        break;
                }

                isupper = char.IsUpper((char)arrayTwo[i]);
                if (isupper == true)
                {
                    upperCharsTwo++;
                }
            }

            Console.WriteLine("Arrays with changed elements look like following:");
            for (int i = 0; i < arrayOne.Length; i++)
            {
                Console.Write(arrayOne[i] + " ");
            }

            Console.WriteLine();
            for (int i = 0; i < arrayTwo.Length; i++)
            {
                Console.Write(arrayTwo[i] + " ");
            }

            Console.WriteLine();
            if (upperCharsOne > upperCharsTwo)
            {
                Console.WriteLine("Array 1 has more upper case letters than array 2");
            }
            else if (upperCharsOne < upperCharsTwo)
            {
                Console.WriteLine("Array 2 has more upper case letters than array 1");
            }
            else
            {
                Console.WriteLine("Array 1 and array 2 have equal number of upper case letters");
            }
        }
    }
}
