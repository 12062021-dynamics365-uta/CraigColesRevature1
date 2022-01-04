using System;

namespace SweetnSaltyConsoleAssignment
{
    class Program
    {
        static void Main(string[] args)
        {

            int threeAndFiveCounter = 0;
            int threeCounter = 0;
            int fiveCounter = 0;
            //List<int> numbers = new List<int>();

            //for loop to loop through numbers 1 - 1000
            for (int i = 1; i <= 1000; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.Write("Sweet'nSalty" + " ");
                    //keeps count how many numbers are multiples of 3 AND 5
                    threeAndFiveCounter++;
                    //if mod 20 = 0, then 2 more lines will be generated for readability
                    if (i % 20 == 0)
                    {
                      Console.Write("\n \n");
                    }

                }
                else if (i % 3 == 0)
                {
                    Console.Write("sweet" + " ");
                    //keeps count how many numbers are multiples of only 3
                    threeCounter++;
                    if (i % 20 == 0)
                    {
                      Console.Write("\n \n");
                    }

                }
                else if (i % 5 == 0)
                {
                    Console.Write("salty" + " ");
                    //keeps count how many numbers are multiples of only 5
                    fiveCounter++;
                    if (i % 20 == 0)
                    {
                      Console.Write("\n \n");
                    }

                }
                else
                {
                   //if a number isn't a multiple of 3 nor 5, just print the number and another space. 
                   Console.Write(i + " ");
                   if (i % 20 == 0)
                   {
                     Console.Write("\n \n");
                   }

                }
            }

            //prints the counts of sweet, salty, and Sweet'nSalty
            Console.WriteLine($"Sweet count: {threeCounter}");
            Console.WriteLine($"Salty count: {fiveCounter}");
            Console.WriteLine($"Sweet'nSalty count: {threeAndFiveCounter}");

        }   
    }
}


               
                
               


                
