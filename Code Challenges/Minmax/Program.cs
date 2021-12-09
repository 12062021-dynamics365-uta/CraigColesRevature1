using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace Minmax
{
    class Result
    {

        /*
         * Complete the 'miniMaxSum' function below.
         *
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static void miniMaxSum(List<int> arr)
        {

            long sum = 0;


            long min = long.MaxValue;
            long max = long.MinValue;

            //iterate through array
            for (int i = 0; i < 5; i++)
            {
                sum += arr[i];

                min = Math.Min(min, arr[i]);
                max = Math.Max(max, arr[i]);

            }

            //print the sum of the max sum of numbers and min sum
            Console.WriteLine((sum - max) + " " + (sum - min));

        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            Result.miniMaxSum(arr);
        }
    }
}
