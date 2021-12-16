using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Serializer
{
    [Serializable]
    public class Emp
    {
        public int id = 1;
        public string name = "Craig-O";
        public double salary = 2000;

    }
    class Program
    {
        static void Main(string[] args)
        {
            Emp e = new Emp();
            //e.id = 1;
            //e.name = "Craig";
            //e.salary = 200;
            //IFormatter format = new BinaryFormatter();
            //Stream st = new FileStream("D:\\ abc.text", FileMode.OpenOrCreate, FileAccess.Write);

            XmlSerializer s = new XmlSerializer(typeof(Emp));
            TextWriter tf = new StreamWriter("E:\\AAA.xml");
            s.Serialize(tf, e);
            tf.Close();

            Console.WriteLine(e.name);
        }
    }
}
