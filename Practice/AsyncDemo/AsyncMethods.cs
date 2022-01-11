using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDemo
{
    class AsyncMethods
    {
        
        internal static async Task MethodAsync1()
        {
            Console.WriteLine("In Async1.");
            Task t1 = Task.Delay(1000);

            Console.WriteLine("waiting 1 second.");

            await t1;
            Console.WriteLine("After waiting 1 second.");
        }

        public static async Task MethodAsync2()
        {
            Console.WriteLine("In Async2");
            Task t2 = Task.Delay(2000);
            Console.WriteLine("Waiting 2 seconds.");
            await t2;
            Console.WriteLine("After waiting 2 seconds.");
        }

        public static async Task MethodAsync3()
        {
            Console.WriteLine("In Async3");
            Task t3 = Task.Delay(3000);
            Console.WriteLine("Waiting 3 seconds.");
            await t3;
            Console.WriteLine("After waiting 3 seconds.");
        }


    }
}
