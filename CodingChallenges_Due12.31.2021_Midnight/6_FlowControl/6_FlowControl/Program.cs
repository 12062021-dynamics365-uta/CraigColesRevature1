using System;

namespace _6_FlowControl
{
    public class Program
    {
        //private username; 
        
        static void Main(string[] args)
        {
            
            Program.GetValidTemperature();
        }

        /// <summary>
        /// This method gets a valid temperature between -40 asnd 135 inclusive from the user
        /// and returns the valid int. 
        /// </summary>
        /// <returns></returns>
        public static int GetValidTemperature()
        {
            Console.WriteLine("Enter a temp: ");
            string userTemp = Console.ReadLine();
            int intTemp = Convert.ToInt32(userTemp);
           
            if(intTemp >= -40 && intTemp <= 135)
            {
                return intTemp;
                Console.WriteLine("Valid temp!");
            }
            else
            {
                return intTemp;
                Console.WriteLine("invalid temp");
            }

            
        }

        /// <summary>
        /// This method has one int parameter
        /// It prints outdoor activity advice and temperature opinion to the console 
        /// based on 20 degree increments starting at -20 and ending at 135 
        /// n < -20, Console.Write("hella cold");
        /// -20 <= n < 0, Console.Write("pretty cold");
        ///  0 <= n < 20, Console.Write("cold");
        /// 20 <= n < 40, Console.Write("thawed out");
        /// 40 <= n < 60, Console.Write("feels like Autumn");
        /// 60 <= n < 80, Console.Write("perfect outdoor workout temperature");
        /// 80 <= n < 90, Console.Write("niiice");
        /// 90 <= n < 100, Console.Write("hella hot");
        /// 100 <= n < 135, Console.Write("hottest");
        /// </summary>
        /// <param name="temp"></param>
        public static void GiveActivityAdvice(int temp)
        {
            
            if(temp < -20)
            {
                Console.WriteLine("hella cold");
            }
            else if (-20 <= temp && temp < 0)
            {
                Console.WriteLine("pretty cold");
            }
            else if (0 <= temp && temp < 20)
            {
                Console.WriteLine("cold");
            }
            else if (20 <= temp && temp < 40)
            {
                Console.WriteLine("thawed out");
            }
            else if (40 <= temp && temp < 60)
            {
                Console.WriteLine("feels like Autumn");
            }
            else if (60 <= temp && temp < 80)
            {
                Console.WriteLine("perfect outdoor workout temperature");
            }
            else if (80 <= temp && temp < 90)
            {
                Console.WriteLine("niiice");
            }
            else if (90 <= temp && temp < 100)
            {
                Console.WriteLine("hella hot");
            }
            else if (100 <= temp && temp < 135)
            {
                Console.WriteLine("hottest");
            }

        }




        /// <summary>
        /// This method gets a username and password from the user
        /// and stores that data in the global variables of the 
        /// names in the method.
        /// </summary>
        public static void Register()
        {
            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string pass = Console.ReadLine();
        }

        /// <summary>
        /// This method gets username and password from the user and
        /// compares them with the username and password names provided in Register().
        /// If the password and username match, the method returns true. 
        /// If they do not match, the user is reprompted for the username and password
        /// until the exact matches are inputted.
        /// </summary>
        /// <returns></returns>
        public static bool Login()
        {
            throw new NotImplementedException($"Login() has not been implemented.");
        }

        /// <summary>
        /// This method has one int parameter.
        /// It checks if the int is <=42, Console.WriteLine($"{temp} is too cold!");
        /// between 43 and 78 inclusive, Console.WriteLine($"{temp} is an ok temperature");
        /// or > 78, Console.WriteLine($"{temp} is too hot!");
        /// For each temperature range, a different advice is given. 
        /// </summary>
        /// <param name="temp"></param>
        public static void GetTemperatureTernary(int temp)
        {
            throw new NotImplementedException($"GetTemperatureTernary() has not been implemented.");
        }
    }//EoP
}//EoN
