using System;

namespace _9_ClassesChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Human human = new Human();
            Human human1 = new Human("Dick", "Butkus");
            Human2 human0 = new Human2("Craig", "Coles", "blue");

            Human2 human2 = new Human2("Pat", "Smyth", 46);

            Human2 human3 = new Human2("Jim", "Johnson", "brown", 36);

        }
    }
}
