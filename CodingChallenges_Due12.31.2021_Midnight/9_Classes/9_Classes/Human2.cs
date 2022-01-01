using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
    internal class Human2
    {
        private string lastName = "Smyth";
        private string firstName = "Pat";
        string eyeColor = "blue";
        int age = 28;
        public int weight { get; set; }

       
           

        
            

        public Human2(string fName, string lName, int age)
        {
            this.firstName = fName;
            this.lastName = lName;
            this.age = age;
        }

        public Human2(string firstName, string lastName, string eyecolor)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColor = eyecolor;
        }
        public Human2(string firstName, string lastName, string eyecolor, int age)
        {
            firstName = this.firstName;
            lastName = this.lastName;
            eyecolor = this.eyeColor;
            age = this.age;
        }

        public Human2(int weight)
        {
            weight = this.weight;
            weight = 34;
        }
        public void AboutMe2()
        {
            Console.WriteLine($"My name is {firstName} {lastName} my eye color is {eyeColor}");
            
            Console.WriteLine($"My name is {firstName} {lastName} My age is {age}");
            
            Console.WriteLine($"My name is {firstName} {lastName} my age is {age} mt eye color is {eyeColor}");
        }
    }
}





            



