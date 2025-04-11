namespace Domain.Entities;

public class Course(int id, string title, int credits)
{
    public int Id { get; set; } = id;
    public string Title { get; set; } = title;
    public int Credits { get; set; } = credits;
}