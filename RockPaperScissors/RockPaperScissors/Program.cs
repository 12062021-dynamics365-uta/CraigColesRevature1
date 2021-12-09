using System;

namespace RockPaperScissors
{
    class Program
    {

        
        public void getWinCounts()
        {

        }


        public static int getWins(int playerCount, int computerCount)
        {
            
            
            
            Console.WriteLine("Player's wins: " + playerCount);
            Console.WriteLine("Computer's wins: " + computerCount);

            return playerCount + computerCount;
        }

        public void

         static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to Rock-Paper-Scissors Game!");

            int convertedNumber = -1;
            bool conversionBool = false;
            string computer;
            string userInput;
            bool playAgain = true;

            int playerCount = 0;
            int computerCount = 0;



            while (playAgain)
            {

                userInput = " ";
                computer = " ";
                
                do
                {
                    Console.WriteLine("Input your choice: \n1 for Rock, 2 for Paper, 3 for Scissors");
                    userInput = Console.ReadLine();

                    conversionBool = Int32.TryParse(userInput, out convertedNumber);

                    if (!conversionBool || convertedNumber < 1 || convertedNumber > 3)
                    {
                        Console.WriteLine("Yo, you didn't enter a 1, 2, or 3!");
                    }
                }
                while (!(convertedNumber > 0 && convertedNumber < 4));


                Random randNum = new Random();
                Console.WriteLine(randNum.Next(1, 4)); //inclusive of the first(lower) value and exclusive of the second(upper) value.

                switch (randNum.Next(1, 4))
                {
                    case 1:
                        computer = "1";
                        break;

                    case 2:
                        computer = "2";
                        break;

                    case 3:
                        computer = "3";
                        break;

                }

                Console.WriteLine("Player: " + userInput);
                Console.WriteLine($"Computer: " + computer);

                switch (userInput)
                {
                    case "1":
                        if (computer == "1")
                        {
                            Console.WriteLine("Draw!");
                        }
                        else if (computer == "2")
                        {
                            Console.WriteLine("Player wins!");
                            playerCount++;
                        }
                        else
                        {
                            Console.WriteLine("Computer wins!");
                            computerCount++;
                        }

                        
                        break;

                    case "2":
                        if (computer == "1")
                        {
                            Console.WriteLine("Computer wins!");
                            computerCount++;

                        }
                        else if (computer == "2")
                        {
                            Console.WriteLine("Draw!");
                        }
                        else
                        {
                            Console.WriteLine("Player wins!");
                            playerCount++;
                        }
                        break;

                    case "3":
                        if (computer == "1")
                        {
                            Console.WriteLine("Player wins!");
                            playerCount++;

                        }
                        else if (computer == "2")
                        {
                            Console.WriteLine("Computer Wins!");
                            computerCount++;
                        }
                        else
                        {
                            Console.WriteLine("Draw!");
                        }
                        break;
                        
                    


                }


               
            

               if(playerCount == 3)
                {
                    Console.WriteLine("Player Wins it all!");
                    playAgain = false;
                    Program.getWins(playerCount, computerCount);

                }
                else if(computerCount == 3)
                {
                    Console.WriteLine("The Computer wins it all!");
                    playAgain = false;
                    Program.getWins(playerCount, computerCount);
                }
                else
                {
                    Console.WriteLine("Tie!");
                    playAgain = false;
                    Program.getWins(playerCount, computerCount);
                }


            }






        }
    }
}
