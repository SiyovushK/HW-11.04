using Domain.Entities;

List<Student> Students = new List<Student>
{
    new Student (1, "Alice", new DateTime(2000, 5, 15) ),
    new Student (2, "Bob", new DateTime(1999, 8, 25) ),
    new Student (3, "Charlie", new DateTime(2001, 3, 10) )
};

List<Course> Courses = new List<Course>
{
    new Course (101, "Mathematics", 4 ),
    new Course (102, "Computer Science", 3 ),
    new Course (103, "Physics", 4 )
};

List<Enrollment> Enrollments = new List<Enrollment>
{
    new Enrollment (1, 1, 101, new DateTime(2023, 1, 15) ),
    new Enrollment (2, 1, 102, new DateTime(2023, 1, 20) ),
    new Enrollment (3, 2, 101, new DateTime(2023, 1, 18) ),
    new Enrollment (4, 3, 103, new DateTime(2023, 1, 22) ),
    new Enrollment (5, 3, 101, new DateTime(2023, 1, 25) ),
    new Enrollment (6, 3, 102, new DateTime(2023, 1, 30) )
};


//Task1
var MathCourse = Enrollments
    .Where(e => Courses.Any(c => c.Id == e.CourseId && c.Title == "Mathematics"))
    .Select(e => Students.First(s => s.Id == e.StudentId))
    .ToList();

var MathCourse2 = (
    from e in Enrollments
    join s in Students on e.StudentId equals s.Id
    join c in Courses on e.CourseId equals c.Id
    where c.Title == "Mathematics"
    select (s.Name, c.Title, e.EnrollmentDate)
).ToList();

foreach (var entry in MathCourse2)
{
    Console.WriteLine($"Student: {entry.Name}, Course: {entry.Title}, Enrollment date: {entry.EnrollmentDate.ToShortDateString()}");
}

System.Console.WriteLine();

//Task2
var Charlie = Enrollments
    .Where(e => Students.Any(s => s.Id == e.StudentId && s.Name == "Charlie"))
    .ToList();

var Charlie2 = (
    from e in Enrollments
    join s in Students on e.StudentId equals s.Id
    join c in Courses on e.CourseId equals c.Id
    where s.Name == "Charlie"
    select (s.Name, c.Title)
).ToList();

foreach (var item in Charlie2)
{
    System.Console.WriteLine($"{item.Name} {item.Title}");
}

System.Console.WriteLine();

//Task3
var Many = Enrollments
    .GroupBy(e => e.StudentId)
    .Where(g => g.Count() > 1)
    .SelectMany(g => Students.Where(s => s.Id == g.Key));

var Many2 = (
    from s in Students
    join e in Enrollments on s.Id equals e.StudentId
    group e by s into g
    where g.Count() > 1
    select g.Key
).ToList();

foreach (var item in Many)
{
    System.Console.WriteLine($"Id: {item.Id}, Name: {item.Name}");
}

System.Console.WriteLine();

//Task5
var result = Students
    .Join(Enrollments, s => s.Id, e => e.StudentId, (s, e) => new {s, e})
    .Join(Courses, se => se.e.CourseId, c => c.Id, (se, c) => new {
        se.s.Name,
        c.Title, 
        c.Credits,
        se.e.EnrollmentDate
    })
    .Where(x => x.EnrollmentDate.Year == 2023 && x.Credits >= 3)
    .OrderBy(x => x.EnrollmentDate);

var result2 = from s in Students
    join e in Enrollments on s.Id equals e.StudentId
    join c in Courses on e.CourseId equals c.Id
    where e.EnrollmentDate.Year == 2023 && c.Credits >= 2
    orderby e.EnrollmentDate, c.Credits
    select new {
        s.Name,
        c.Title,
        c.Credits,
        e.EnrollmentDate
    };

foreach (var item in result2)
{
    System.Console.WriteLine($"Student name: {item.Name}, Course: {item.Title}, Credits: {item.Credits}, Enrollment date {item.EnrollmentDate}");
}

//Task6
var TotalCredits = Students
    .Join(Enrollments, s => s.Id, e => e.StudentId, (s, e) => new { s, e })
    .Join(Courses, se => se.e.CourseId, c => c.Id, (se, c) => new { se.s.Name, c.Credits })
    .GroupBy(x => x.Name)
    .Select(g => new {
        StudentName = g.Key,
        TotalCredits = g.Sum(x => x.Credits)
    });

var TotalCredits2 =
    from e in Enrollments
    join c in Courses on e.CourseId equals c.Id
    join s in Students on e.StudentId equals s.Id
    group c.Credits by s.Name into g
    select new {
        StudentName = g.Key,
        TotalCredits = g.Sum()
    };

foreach (var item in TotalCredits2)
{
    System.Console.WriteLine($"Name: {item.StudentName}, Total credits: {item.TotalCredits}");
}

//Task7
var TotalStudents = 
    from e in Enrollments
    join c in Courses on e.CourseId equals c.Id
    group e by c.Title into g
    select new {
        CourseTitle = g.Key,
        TotalStudents = g.Count()
    };  

foreach (var course in TotalStudents)
{
    Console.WriteLine($"Course: {course.CourseTitle}, Students total: {course.TotalStudents}");
}

//Task8
var Bob2 = (
    from e in Enrollments
    join s in Students on e.StudentId equals s.Id
    join c in Courses on e.CourseId equals c.Id
    where s.Name != "Bob"
    select (s.Name, c.Title)
).ToList();

foreach (var item in Bob2)
{
    System.Console.WriteLine($"{item.Name} {item.Title}");
}