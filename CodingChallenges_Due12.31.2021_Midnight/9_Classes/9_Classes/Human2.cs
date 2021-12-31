using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
    internal class Human2
    {
        private string lastName = "Smyth";
        private string firstName = "Pat";
        string eyecolor = "blue";
        int age = 28;

        public Human2(string firstName, string lastName, string eyecolor, int age)
        {
            firstName = this.firstName;
            lastName = this.lastName;
            eyecolor = this.eyecolor;
            age = this.age;
        }
        public Human2(string firstName, string lastName, int age)
        {

        }

        public Human2(string firstName, string lastName, string eyecolor)
        {

        }




        Human noArgs = new Human();
        Human Args = new Human("Pat", "Smyth");

        public void AboutMe()
        {
            Console.WriteLine($"My name is {firstName} {lastName}");
            noArgs.AboutMe();
            Args.AboutMe();

        }
    }
}