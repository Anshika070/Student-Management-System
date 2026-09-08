public class Course
{
    public int Id { get; }
    public string Name { get; set; }
    public string Instructor { get; set; }

    public Course(int id, string name, string instructor)
    {
        Id = id;
        Name = name;
        Instructor = instructor;
    }

    public void DisplayCourse()
    {
        Console.WriteLine(
            $"Course ID: {Id} | Name: {Name} | Instructor: {Instructor}"
        );
    }
}