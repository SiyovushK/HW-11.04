# LINQ tasks

## There are some tasks for home with LINQ query.

## Есть несколько задач для дома с запросом LINQ.

- #### Now you must work with array or list. First of all you must create a class, Student,Course and Enrollment with some properties. Than create list or array of Student with more tnan 5 elements.

- #### Теперь вам предстоит работать с массивом или списком. Прежде всего, вы должны создать класс Student, Course и Enrollment с некоторыми свойствами. Затем создайте список или массив Student с более чем 5 элементами.

## Student

#### Property :

- Id (int)
- Name (string)
- DateOfBirth (DateTime)

## Course

#### Property :

- Id (int)
- Title (string)
- Credits (int)

## Enrollment

#### Property :

- Id (int)
- StudentId (int)
- CourseId (int)
- EnrollmentDate (DateTime)

### You can use these objects

### Вы можете использовать эти объекты

```cs
List<Student> students = new List<Student>
{
new Student { StudentId = 1, Name = "Alice", DateOfBirth = new DateTime(2000, 5, 15) },
new Student { StudentId = 2, Name = "Bob", DateOfBirth = new DateTime(1999, 8, 25) },
new Student { StudentId = 3, Name = "Charlie", DateOfBirth = new DateTime(2001, 3, 10) }
};


List<Course> courses = new List<Course>
{
new Course { CourseId = 101, Title = "Mathematics", Credits = 4 },
new Course { CourseId = 102, Title = "Computer Science", Credits = 3 },
new Course { CourseId = 103, Title = "Physics", Credits = 4 }
};


List<Enrollment> enrollments = new List<Enrollment>
{
new Enrollment { EnrollmentId = 1, StudentId = 1, CourseId = 101, EnrollmentDate = new DateTime(2023, 1, 15) },
new Enrollment { EnrollmentId = 2, StudentId = 1, CourseId = 102, EnrollmentDate = new DateTime(2023, 1, 20) },
new Enrollment { EnrollmentId = 3, StudentId = 2, CourseId = 101, EnrollmentDate = new DateTime(2023, 1, 18) },
new Enrollment { EnrollmentId = 4, StudentId = 3, CourseId = 103, EnrollmentDate = new DateTime(2023, 1, 22) },
new Enrollment { EnrollmentId = 5, StudentId = 3, CourseId = 101, EnrollmentDate = new DateTime(2023, 1, 25) },
new Enrollment { EnrollmentId = 6, StudentId = 3, CourseId = 102, EnrollmentDate = new DateTime(2023, 1, 30) }
};
```

##

### Task 1

Find all students who are enrolled in the "Mathematics" course.

Найдите всех студентов, обучающихся по курсу «Математика».

### Task 2

Find all courses that "Charlie" is enrolled in.

Найдите все курсы, на которые записан «Чарли».

### Task 3

Using SelectMany with Hierarchical Data: Flatten a list of enrollments and select students who are enrolled in multiple courses.

Использование SelectMany с иерархическими данными: сведите список зачисленных и выберите студентов, которые зачислены на несколько курсов.

### Task 4

Group students by age range and then by course, and calculate the average age for each group

Сгруппируйте учащихся по возрастному диапазону, а затем по курсам и рассчитайте средний возраст для каждой группы.

### Task 5

Join Student, Enrollment, and Course and filter by enrollment date and course credits.

Присоединяйте Student, Enrollment и Course и фильтруйте по дате зачисления и кредитам курса.

### Task 6

Calculate the total credits each student has enrolled in.

Подсчитайте общее количество кредитов, на которые записался каждый студент.

### Task 7

Find the number of students enrolled in each course.

Найдите количество студентов, обучающихся на каждом курсе.

### Task 8

Find all courses that a specific student, say "Bob", is not enrolled in.

Найдите все курсы, на которые не записан конкретный студент, например «Боб».
