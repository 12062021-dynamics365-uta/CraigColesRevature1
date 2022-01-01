using System;

namespace _3_DataTypeAndVariablesChallenge
{
    public class Program
    {
        private const double V = 2.0233434;

        public static void Main(string[] args)
        {
            //
            //
            // Insert code here.
            //
            //
            byte b = 0;
            SByte sb = -128;
            Int32 iThirTwo = 2147483647;
            UInt32 uInt = 0;
            Int64 intSixFour = 9223372036854775807;
            UInt64 uIntSix4 = 0;
            float myFloat = -31.1289f;
            double d = 3.23291494;
            char c = 'c';
            bool b1 = false;
            object obj1 = 2;
            string str = "Hello";
            decimal dec = 3.001002003m;
            Console.WriteLine(b);
            Console.WriteLine(sb);
            Console.WriteLine(iThirTwo);
            Console.WriteLine(uInt);
            Console.WriteLine(intSixFour);
            Console.WriteLine(uIntSix4);
            Console.WriteLine(myFloat);
            Console.WriteLine(d);
            Console.WriteLine(c);
            Console.WriteLine(b1);
            Console.WriteLine(obj1);
            Console.WriteLine(str);
            Console.WriteLine(dec);


            string s1 = "I control text";
            int numString = 28;
           
        }

        /// <summary>
        /// This method has an 'object' type parameter. 
        /// 1. Create a switch statement that evaluates for the data type of the parameter
        /// 2. You will need to get the data type of the parameter in the 'case' part of the switch statement
        /// 3. For each data type, return a string of exactly format, "Data type => <type>" 
        /// 4. For example, an 'int' data type will return ,"Data type => int",
        /// 5. A 'ulong' data type will return "Data type => ulong",
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string PrintValues(object obj)
        {
            Type type = obj.GetType();
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte: return "Data type => byte";

                case TypeCode.SByte:  return "Data type => sbyte";

                case TypeCode.Int32: return "Data type => int";

                case TypeCode.UInt32: return "Data type => uint";

                case TypeCode.Int16: return "Data type => short";

                case TypeCode.UInt16: return "Data type => ushort";

                case TypeCode.Int64: return "Data type => long";

                case TypeCode.UInt64: return "Data type => ulong";

                case TypeCode.Single: return "Data type => float";

                case TypeCode.Double: return "Data type => double";

                case TypeCode.Char: return "Data type => char";

                case TypeCode.Boolean: return "Data type => Boolean";

                case TypeCode.Object: return "Data type => object";

                case TypeCode.String: return "Data type => string";

                case TypeCode.Decimal: return "Data type => decimal";




            }
            return "Data type => <type>";
        }

        /// <summary>
        /// THis method has a string parameter.
        /// 1. Use the .TryParse() method of the Int32 class (Int32.TryParse()) to convert the string parameter to an integer. 
        /// 2. You'll need to investigate how .TryParse() and 'out' parameters work to implement the body of StringToInt().
        /// 3. If the string cannot be converted to a integer, return 'null'. 
        /// 4. Investigate how to use '?' to make non-nullable types nullable.
        /// </summary>
        /// <param name="numString"></param>
        /// <returns></returns>
        public static int? StringToInt(string numString)
        {
            //throw new NotImplementedException($"StringToInt() has not been implemented");

            int x;
            bool success = Int32.TryParse(numString, out x);

            if (success)
            {
                Console.WriteLine(x);
            }
            else
            {
                return null;
            }
            return x;

        }
    }// end of class
}// End of Namespace
