using System;
using System.Collections.Generic;
using System.Linq;

public class StudentManager
{
    private List<Student> students = new List<Student>();

    public void AddStudent(Student student)
    {
        students.Add(student);

        Console.WriteLine("Student added successfully!");
    }

    public void DisplayStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        foreach (Student student in students)
        {
            Console.WriteLine(
                $"ID: {student.Id} | " +
                $"Name: {student.Name} | " +
                $"Age: {student.Age} | " +
                $"Average: {student.GetAverage():F2} | " +
                $"Grade: {student.GetGrade()}"
            );
        }
    }

    public Student? FindStudentById(int id)
    {
        return students.FirstOrDefault(s => s.Id == id);
    }

    public void SearchStudents(string name)
    {
        var results = students
            .Where(s => s.Name.ToLower().Contains(name.ToLower()))
            .ToList();

        if (results.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        foreach (Student student in results)
        {
            Console.WriteLine(
                $"{student.Id} - {student.Name}"
            );
        }
    }

    public void ShowTopStudents()
    {
        var topStudents = students
            .OrderByDescending(s => s.GetAverage())
            .ToList();

        Console.WriteLine("\n--- Top Students ---");

        foreach (Student student in topStudents)
        {
            Console.WriteLine(
                $"{student.Name} - {student.GetAverage():F2}"
            );
        }
    }
}