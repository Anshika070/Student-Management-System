class Student
{
    public string Name;
    public int Marks;

    public Student(string name, int marks)
    {
        Name = name;
        Marks = marks;
    }

    public bool HasPassed()
    {
        return Marks >= 40;
    }
}