using System;
using System.Collections.Generic;

namespace _7_GuessingGameChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> guessNums = new List<int>();
            int randomNum = Program.GetRandomNumber();
            bool restart = false;
            int turns = 0;
            do {
                do
                {
                    
                    int userGuess = GetUsersGuess();
                    int round = CompareNums(randomNum, userGuess);
                    guessNums.Add(userGuess);

                    if (round == -1)
                    {
                        Console.WriteLine("Too high. Try again.");
                        turns++;
                    }
                    else if (round == 1)
                    {
                        Console.WriteLine("Too low.");
                        turns++;
                    }
                    else if (round == 0)
                    {
                        Console.WriteLine("win!");
                        turns = -1;
                    }
                } while (turns > 5 && turns != 0);

                if (turns == 5)
                {
                    Console.WriteLine("You ran out of guess!");
                }
                else if (turns == -1)
                {
                    Console.WriteLine("You win!");
                }

                 restart = PlayGameAgain();

            } while (restart == true);

    
            //ran out of time to get the flow right. 
              
        }

        /// <summary>
        /// This method returns a randomly chosen number between 1 and 100, inclusive.
        /// </summary>
        /// <returns></returns>
        public static int GetRandomNumber()
        {
            Random randomGen = new Random();
            //create a variable for a random number between 1 and 100
            int randomNum = randomGen.Next(1, 100);
            Console.WriteLine(randomNum);
            return randomNum;
        }

        /// <summary>
        /// This method gets input from the user, 
        /// verifies that the input is valid and 
        /// returns an int.
        /// </summary>
        /// <returns></returns>
        public static int GetUsersGuess()
        {

            int playerGuess = 0;
            try
            {
            Console.WriteLine("Guess a number between 1 and 100: ");
            //parsing the player's guess to an interger(inputInt)
            playerGuess = Convert.ToInt32(Console.ReadLine());
                
            }
            //Exception handled incase user enters something other than an int.
            catch(Exception e)
            {
                Console.WriteLine("Invalid input!");
                
            }
            return playerGuess;
        }

        /// <summary>
        /// This method will has two int parameters.
        /// It will:
        /// 1) compare the first number to the second number
        /// 2) return -1 if the first number is less than the second number
        /// 3) return 0 if the numbers are equal
        /// 4) return 1 if the first number is greater than the second number
        /// </summary>
        /// <param name="randomNum"></param>
        /// <param name="guess"></param>
        /// <returns></returns>
        public static int CompareNums(int randomNum, int guess)
        {
            
            bool rightGuess = false;
            //do
            //{
                if (randomNum < guess)
                {
                    
                    
                    return -1;
                }
                else if (randomNum == guess)
                {
                    
                    
                    return 0;

                }
                else if (randomNum > guess)
                {
                    
                    
                    return 1;
                }
            //}
            //while (rightGuess == true); 
            return guess;

            
            
        }

        /// <summary>
        /// This method offers the user the chance to play again. 
        /// It returns true if they want to play again and false if they do not.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool PlayGameAgain()
        {
            bool endGame = false;
           
                Console.WriteLine("Would you like to play again?");
                string userChoice = Console.ReadLine();
                if (userChoice == "y")
                {
                    
                    endGame = false;
                }
                else if (userChoice == "n")
                {
                    endGame = true;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            
           return endGame;
        
        }
    }
}
