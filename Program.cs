using System;

class Program
{
    static StudentManager studentManager = new StudentManager();

    static void Main()
    {
        SeedData();

        bool running = true;

        while (running)
        {
            DisplayMenu();

            Console.Write("Choose an option: ");
            string? input = Console.ReadLine();

            try
            {
                int choice = int.Parse(input ?? "");

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;

                    case 2:
                        studentManager.DisplayStudents();
                        break;

                    case 3:
                        SearchStudent();
                        break;

                    case 4:
                        studentManager.ShowTopStudents();
                        break;

                    case 5:
                        AddMarks();
                        break;

                    case 6:
                        ShowStudentDetails();
                        break;

                    case 7:
                        running = false;
                        Console.WriteLine("Thank you for using the app!");
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number.");
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();

            Console.Clear();
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("================================");
        Console.WriteLine("     STUDENT MANAGEMENT APP");
        Console.WriteLine("================================");
        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. View Students");
        Console.WriteLine("3. Search Student");
        Console.WriteLine("4. Show Top Students");
        Console.WriteLine("5. Add Marks");
        Console.WriteLine("6. Student Details");
        Console.WriteLine("7. Exit");
        Console.WriteLine("================================");
    }

    static void AddStudent()
    {
        Console.Write("Enter student ID: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Enter student name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter student age: ");
        int age = int.Parse(Console.ReadLine() ?? "0");

        Student student = new Student(id, name, age);

        studentManager.AddStudent(student);
    }

    static void SearchStudent()
    {
        Console.Write("Enter name to search: ");

        string name = Console.ReadLine() ?? "";

        studentManager.SearchStudents(name);
    }

    static void AddMarks()
    {
        Console.Write("Enter student ID: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

        Student? student = studentManager.FindStudentById(id);

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.Write("Enter mark: ");
        double mark = double.Parse(Console.ReadLine() ?? "0");

        if (mark < 0 || mark > 100)
        {
            Console.WriteLine("Marks must be between 0 and 100.");
            return;
        }

        student.Marks.Add(mark);

        Console.WriteLine("Mark added successfully.");
    }

    static void ShowStudentDetails()
    {
        Console.Write("Enter student ID: ");

        int id = int.Parse(Console.ReadLine() ?? "0");

        Student? student = studentManager.FindStudentById(id);

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.WriteLine("\n--- Student Details ---");
        Console.WriteLine($"ID: {student.Id}");
        Console.WriteLine($"Name: {student.Name}");
        Console.WriteLine($"Age: {student.Age}");

        Console.WriteLine("\nMarks:");

        foreach (double mark in student.Marks)
        {
            Console.WriteLine(mark);
        }

        Console.WriteLine($"Average: {student.GetAverage():F2}");
        Console.WriteLine($"Grade: {student.GetGrade()}");
    }

    static void SeedData()
    {
        Student student1 = new Student(1, "Anshika", 21);
        student1.Marks.Add(90);
        student1.Marks.Add(85);
        student1.Marks.Add(92);

        Student student2 = new Student(2, "Rahul", 22);
        student2.Marks.Add(75);
        student2.Marks.Add(80);
        student2.Marks.Add(78);

        studentManager.AddStudent(student1);
        studentManager.AddStudent(student2);
    }
}