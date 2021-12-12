using System;
using System.Collections;
using System.Collections.Generic;


public class student
{
    public string name
    { get; set; }

    public int age
    { get; set; }
    
    public string BioGrade
    { get; set; }

    public string MathGrade
    { get; set; }

    public string BandGrade
    { get; set; }

    public string ChemGrade
    { get; set; }

    public string HTMLGrade
    { get; set; }

}
class Program
{
    static void Main(string[] args)
    {
        student stu = new student()
        {
            name = "Rose",
            age = 22,
            BioGrade = "C+",
            MathGrade = "B",
            BandGrade = "A",
            ChemGrade = "A",
            HTMLGrade = "C",
        };
        
        student stu1 = new student()
        {
            age = 21,
            name = "Donkey",
            BioGrade = "D",
            MathGrade = "D",
            BandGrade = "D",
            ChemGrade = "D",
            HTMLGrade = "D",
        };
        student stu2 = new student()
        {
            age = 46,
            name = "Stan",
            BioGrade = "D-",
            MathGrade = "B",
            BandGrade = "A",
            ChemGrade = "A",
            HTMLGrade = "D",
        };
        student stu3 = new student()
        {
            age = 25,
            name = "Lee",
            BioGrade = "A",
            MathGrade = "B",
            BandGrade = "B",
            ChemGrade = "A",
            HTMLGrade = "D",
        };
        student stu4 = new student()
        {
            age = 31,
            name = "Mary",
            BioGrade = "B+",
            MathGrade = "B",
            BandGrade = "B",
            ChemGrade = "A",
            HTMLGrade = "A",
        };
        List<student> em = new List<student>();
        em.Add(stu);
        em.Add(stu1);
        em.Add(stu2);
        em.Add(stu3);
        em.Add(stu4);

        Console.WriteLine("retrieving all student's data: \n");
        
        Console.WriteLine("name: {0}\nage: {1}\nBioGrade:  {2}\nMathGrade: {3}\nBandGrade: {4}\nChemGrade: {5}\n" 
             +"HTMLGrade: {6}\n", stu.name, stu.age, stu.BioGrade, stu.MathGrade, stu.BandGrade, stu.ChemGrade, stu.HTMLGrade);
        
        Console.WriteLine("name: {0}\nage: {1}\nBioGrade:  {2}\nMathGrade: {3}\nBandGrade: {4}\nChemGrade: {5}\n"
             + "HTMLGrade: {6}\n", stu1.name, stu1.age, stu1.BioGrade, stu1.MathGrade, stu1.BandGrade, stu1.ChemGrade, stu1.HTMLGrade);

        Console.WriteLine("name: {0}\nage: {1}\nBioGrade:  {2}\nMathGrade: {3}\nBandGrade: {4}\nChemGrade: {5}\n"
             + "HTMLGrade: {6}\n", stu2.name, stu2.age, stu2.BioGrade, stu2.MathGrade, stu2.BandGrade, stu2.ChemGrade, stu2.HTMLGrade);

        Console.WriteLine("name: {0}\nage: {1}\nBioGrade:  {2}\nMathGrade: {3}\nBandGrade: {4}\nChemGrade: {5}\n"
             + "HTMLGrade: {6}\n", stu3.name, stu3.age, stu3.BioGrade, stu3.MathGrade, stu3.BandGrade, stu3.ChemGrade, stu3.HTMLGrade);

        Console.WriteLine("name: {0}\nage: {1}\nBioGrade:  {2}\nMathGrade: {3}\nBandGrade: {4}\nChemGrade: {5}\n"
             + "HTMLGrade: {6}\n", stu4.name, stu4.age, stu4.BioGrade, stu4.MathGrade, stu4.BandGrade, stu4.ChemGrade, stu4.HTMLGrade);




    }
}
