using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
    internal class Human
    {
        private string lastName = "Smyth";
        private string firstName = "Pat";

        public Human()
        {
        
        }
        public Human(string firstName, string lastName)
        {
            firstName = this.firstName;
            lastName = this.lastName;
        }


        Human noArgs = new Human();
        Human Args = new Human("Pat", "Smyth");

        public void AboutMe()
        {
            Console.WriteLine($"My name is {firstName} {lastName}");
            noArgs.AboutMe();
            Args.AboutMe();
            
        }
        
        




    }//end of class
}//end of namespace