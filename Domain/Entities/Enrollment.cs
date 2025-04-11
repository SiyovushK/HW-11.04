namespace Domain.Entities;

public class Enrollment(int id, int studentId, int courseId, DateTime enrollmentDate)
{
    public int Id { get; set; } = id;
    public int StudentId { get; set; } = studentId;
    public int CourseId { get; set; } = courseId;
    public DateTime EnrollmentDate { get; set; } = enrollmentDate;
}