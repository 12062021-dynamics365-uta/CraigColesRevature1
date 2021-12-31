using System;
using System.Collections.Generic;

namespace _7_GuessingGameChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int randomNum = Program.GetRandomNumber();
            
            
            int guess = Program.GetUsersGuess();
           
            Program.CompareNums(randomNum, guess);
            Program.PlayGameAgain();
        }

        /// <summary>
        /// This method returns a randomly chosen number between 1 and 100, inclusive.
        /// </summary>
        /// <returns></returns>
        public static int GetRandomNumber()
        {
            Random randomGen = new Random();
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

            //parsing the player's guess to an interger(inputInt)
            int playerGuess = 0;
            try
            {
            Console.WriteLine("Guess a number between 1 and 100: ");
            playerGuess = Convert.ToInt32(Console.ReadLine());
                
            }
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
            do
            {
                if (randomNum < guess)
                {
                    Console.WriteLine("Guess lower.");
                    rightGuess = false;
                    return -1;
                }
                else if (randomNum == guess)
                {
                    Console.WriteLine("Your guess was correct!");
                    rightGuess = true;
                    return 0;

                }
                else if (randomNum > guess)
                {
                    Console.WriteLine("Guess higher.");
                    rightGuess = false;
                    return 1;
                }
            }
            while (rightGuess == false); 
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
                if (userChoice == "yes")
                {
                    
                    endGame = false;
                }
                else
                {
                    endGame = true;
                }
            
           return endGame;
        
        }
    }
}
