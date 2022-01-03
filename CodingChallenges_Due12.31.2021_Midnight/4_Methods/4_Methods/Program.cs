using System;

namespace _4_MethodsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /**
                YOUR CODE HERE.
            **/
           
            Console.WriteLine(Program.GetName());
            string friendName = "Emily";
            Console.WriteLine(Program.GreetFriend(friendName));
            Console.WriteLine(Program.GetNumber());
            Console.WriteLine(Program.GetAction());
            double x = 0;
            double y = 0;
            int action = 0;
            Console.WriteLine(Program.DoAction(x, y, action));
        }

        public static string GetName()
        {
            Console.WriteLine("What is your name?");
            string userName = Console.ReadLine();
            return userName;
        }

        public static string GreetFriend(string name)
        {
            
            
           return $"Hello, {name}. You are my friend.";
           
        }

        public static double GetNumber()
        {
            bool Valid = false;
            double userNumber = 0.0;

            while (Valid == false)
            {
                Console.WriteLine("Please enter a number: ");
                string userInput = Console.ReadLine();

                //bool parsed = double.Parse(userInput, out userNumber);
                if (double.TryParse(userInput, out userNumber))
                {
                    Valid = true;
                }
                else
                {
                    Console.WriteLine("Not a double value, please try again.");
                }
            }
            
            return userNumber;

        }

        public static int GetAction()
        {
            //Console.WriteLine("Enter your next action: ");
            //throw new NotImplementedException("DoAction() is not implemented yet");
            
            
            bool exitActions = false;
            int num1, num2; 
            int result = 0;

                Console.WriteLine("What action, foo? (1, 2, 3, 4)");
                int userinput = Convert.ToInt32(Console.ReadLine());

            switch (userinput)
            {
                case 1:
                    {
                        result = 1;
                        break;
                    }
               case 2:
                    {
                        result = 2;
                        break;
                    }
               case 3:
                    {
                        result = 3;
                        break;
                    }
                case 4:
                    {
                        result = 4;
                        break;
                    }
                default:
                    Console.WriteLine("Invalid input. Try again!");
                    break;


            }
            return result;


        }





        public static double DoAction(double x, double y, int action)
        {
            double result;
            switch (action)
            {
                case 1:
                    result = x + y;
                    break;

                case 2:
                    result = y - x;
                    break;
                
                case 3:
                    result = x * y;
                    break;
               
                case 4:
                    result = x / y;
                    break;
                    
                default:
                    throw new FormatException("typeof(System.FormatException");
            }
            return result;
                    
                
                    
                   
                    


        }
    }
}
