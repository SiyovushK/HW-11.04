namespace Domain.Entities;

public class Student(int id, string name, DateTime dateOfBirth)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public DateTime DateOfBirth { get; set; } = dateOfBirth;
}