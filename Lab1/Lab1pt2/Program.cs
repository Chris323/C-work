using System;

namespace Lab1pt2
{
    class SortedListCheck
    {
        static void Main(string[] args)
        {

            var sorted1 = true;
            var sorted2 = true;

            Console.WriteLine("Enter List: ");
            string[] input = Console.ReadLine().Split(",");
            int[] arrayo= Array.ConvertAll(input, int.Parse);

            //Ascending order
            for (int i = 0; i < arrayo.Length - 1; i++)
            {
                if (arrayo[i] > arrayo[i + 1])
                {
                    sorted1 = false;
                    break;
                }
            }
            //Descending
            for (int i = arrayo.Length - 2; i >= 0; i--)
            {
                if (arrayo[i] < arrayo[i + 1])
                {
                    sorted2 = false;
                    break;
                }

            }


            if (sorted1 || sorted2 == true)
            {
                Console.WriteLine("The list is sorted");
            }

 /*           else if (sorted2 == true)
            {
                Console.WriteLine("The list is sorted Descending.");
            }*/

            else
            {
                Console.WriteLine("The list is not sorted");
            }


        }
    }
}
