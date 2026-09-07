class Program
{
    static void Main()
    {
        Student student = new Student("Anshika", 35);

        Console.WriteLine(student.Name);
        Console.WriteLine(student.Marks);

        if (student.HasPassed())
        {
            Console.WriteLine("Student Passed!");
        }
        else
        {
            Console.WriteLine("Student Failed!");
        }
    }
}