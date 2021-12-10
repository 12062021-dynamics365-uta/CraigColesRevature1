using System;
using System.Collections;
using System.Collections.Generic;


public class student
{
    public int age
    { get; set; }
    public string name
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
            age = 22,
            name = "Rose",
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


        Console.WriteLine("retrieving the first student's data ");
        Console.WriteLine("age={0},name={1},BioGrade={3}, MathGrade={4}, BandGrade={4}, ChemGrade={5}, HTMLGrade={6},", stu.age, stu.name, stu.BioGrade, stu.MathGrade, stu.BandGrade, stu.ChemGrade, stu.HTMLGrade);




    }
}
