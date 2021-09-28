using System;

namespace Lab1
{
    class SingleDigitAddition
    {
        static void Main(string[] args)
        {
            Random randomnum = new Random();

            var status = "y";

            while (status == "y") {

                var a = randomnum.Next(10);
                var b = randomnum.Next(10);

                var answer = a + b;

                Console.WriteLine($"{a} + {b} = ");
                var input = Console.ReadLine();
                int userAnswer = int.Parse(input);

                if(answer == userAnswer) { 
                    Console.WriteLine("Your answer is correct");
                }

                else { 
                    Console.WriteLine("Your answer is incorrect");
                }

                Console.WriteLine("Would you like to try again?");
                var tryAgain = Console.ReadLine();


                if (tryAgain.Equals("y", StringComparison.InvariantCultureIgnoreCase)){
                    status = "y";
                }
                else{
                    status = "n";
                }
                


            }
        }
    }
}
