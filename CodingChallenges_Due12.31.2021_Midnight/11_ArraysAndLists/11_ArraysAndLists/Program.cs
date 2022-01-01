using System;
using System.Collections;
using System.Collections.Generic;

namespace _11_ArraysAndListsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {

        }//EoM

        /// <summary>
        /// This method takes an array of integers and returns a double, the average 
        /// value of all the integers in the array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static double AverageOfValues(int[] array)
        {
            int sum = 0;
            double average = 0.0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            average = (double)sum / array.Length;
            return average;
        }

        /// <summary>
        /// This method increases each array element by 2 and 
        /// returns an array with the altered values.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int[] SunIsShining(int[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                //adds two to each element in the array.
                x[i] += 2;
            }
            return x;
        }

        /// <summary>
        /// This method takes an ArrayList containing types of double, int, and string 
        /// and returns the average of the ints and doubles only, as a decimal.
        /// It ignores the string values and rounds the result to 3 decimal places toward the nearest even number.
        /// </summary>
        /// <param name="myArrayList"></param>
        /// <returns></returns>
        public static decimal ArrayListAvg(ArrayList myArrayList)
        {
            decimal returnDec = 0;
            int counter = 0;
            for (int i = 0; i < myArrayList.Count; i++){
                
                if(myArrayList[i].GetType() != typeof(string))// if type is not a string,
                {
                    //only returns the ints and doubles, converts them to decimal
                    returnDec += Convert.ToDecimal(myArrayList[i]);
                    //counts numbers and adds one per loop
                    counter++;
                }
            }

            return Math.Round(returnDec / counter, 3);//In a Math.Round method rounds to the 3rd decimal place
        }

        /// <summary>
        /// This method returns the rank (starting with 1st place) of a new 
        /// score entered into a list of randomly ordered scores.
        /// </summary>
        /// <param name="myArray1"></param>
        public static int ListAscendingOrder(List<int> scores, int yourScore)
        {
            int rank = 0;
            //adds the int yourScoure to the list of coures.
            scores.Add(yourScore);
            //sorts the list of scores.
            scores.Sort();
            //
            rank = scores.IndexOf(yourScore);

            return ++rank;


        }

        /// <summary>
        /// This method has with two parameters takes a List<string> and a string.
        /// The method returns true if the string parameter is found in the List, otherwise false.
        /// </summary>
        /// <param name="myArray2"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool FindStringInList(List<string> myArray2, string word)
        {
            
            if (myArray2.Contains(word))
            {
                //returns true if the list of string contains the string word value
                return true;
            }
            else
            {
                return false;
            }
        }
    }//EoP
}// EoN