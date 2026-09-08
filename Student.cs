using System;
using System.Collections.Generic;

public class Student
{
    public int Id { get; }
    public string Name { get; set; }
    public int Age { get; set; }

    public List<double> Marks { get; set; }

    public Student(int id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
        Marks = new List<double>();
    }

    public double GetAverage()
    {
        if (Marks.Count == 0)
        {
            return 0;
        }

        double total = 0;

        foreach (double mark in Marks)
        {
            total += mark;
        }

        return total / Marks.Count;
    }

    public string GetGrade()
    {
        double average = GetAverage();

        if (average >= 90)
        {
            return "A";
        }
        else if (average >= 75)
        {
            return "B";
        }
        else if (average >= 60)
        {
            return "C";
        }
        else if (average >= 40)
        {
            return "D";
        }
        else
        {
            return "F";
        }
    }
}