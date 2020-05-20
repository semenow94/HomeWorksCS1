using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Переделать программу «Пример использования коллекций» для решения следующих задач:
//а) Подсчитать количество студентов учащихся на 5 и 6 курсах;                                               +
//б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(частотный массив);        +
//в) отсортировать список по возрасту студента;                                                              +
//г) * отсортировать список по курсу и возрасту студента;                                                    +
//д) разработать единый метод подсчета количества студентов по различным параметрам
//выбора с помощью делегата и методов предикатов.
//Семенов Дмитрий
namespace HomeWork6
{
    partial class Tasks
    {
        class Student
        {
            public string LastName { get; private set; }
            public string FirstName { get; private set; }
            public string Univercity { get; private set; }
            public string Faculty { get; private set; }
            public int Course { get; private set; }
            public string Department { get; private set; }
            public int Group { get; }
            public string City { get; private set; }
            public int Age { get; private set; }

            //Создаем конструктор
            public Student(string firstName, string lastName, string univercity, string faculty, string department, int age, int course, int group, string city)
            {
                this.LastName = lastName;
                this.FirstName = firstName;
                this.Univercity = univercity;
                this.Faculty = faculty;
                this.Department = department;
                this.Course = course;
                this.Age = age;
                this.Group = group;
                this.City = city;
            }


            public override string ToString()
            {
                return String.Format("{0,15}{1,15}{2,15}{3,15}{4,15}{5,15}{6,15}{7,5}{8,10}", FirstName, LastName, Univercity, Faculty, Department, Age, Course, Group, City);
            }
        }

        delegate bool Is(Student s);
        delegate bool Is2(Student s, int x);

        static int Comparer(Student st1, Student st2)//Создаем метод для сравнения для экземпляров
        {
            //Сравниваем две строки
            return String.Compare(st1.FirstName, st2.FirstName);
        }
        static int ComparerCourse(Student st1, Student st2)//Создаем метод для сравнения для экземпляров
        {
            return st1.Course - st2.Course;
        }
        static int ComparerAge(Student st1, Student st2)//Создаем метод для сравнения для экземпляров
        {
            return st1.Age - st2.Age;
        }
        static int ComparerCourseAndAge(Student st1, Student st2)//Создаем метод для сравнения для экземпляров
        {
            if (st1.Course < st2.Course) return -1;
            if (st1.Course > st2.Course) return 1;
            return st1.Age - st2.Age;
        }

        //Предикат
        static bool IsAgeBigger18(Student student)
        {
            return student.Age > 18;
        }
        static bool IsMagistr(Student student)
        {
            return student.Course == 6;
        }
        static bool IsBakalavr(Student student)
        {
            return student.Course == 4;
        }
        static bool IsCourse(Student student, int course)
        {
            return student.Course == course;
        }
        static bool IsAge(Student student, int age)
        {
            return student.Age == age;
        }

        static int CountStudents(List<Student> students, Is IS)
        {
            int count = 0;
            foreach (Student student in students)
            {
                if (IS(student)) count++;
            }
            return count;
        }
        static int CountStudents(List<Student> students, int x, Is2 IS)
        {
            int count = 0;
            foreach (Student student in students)
            {
                if (IS(student, x)) count++;
            }
            return count;
        }
        static void CountAgesOnCourses(List<Student> students, int starAge, int endAge)
        {
            Dictionary<int, int> onCource = new Dictionary<int, int>();
            onCource.Add(1, 0);
            onCource.Add(2, 0);
            onCource.Add(3, 0);
            onCource.Add(4, 0);
            onCource.Add(5, 0);
            onCource.Add(6, 0);
            foreach(Student a in students)
            {
                if (a.Age >= starAge && a.Age <= endAge)
                {
                    onCource[a.Course]+= 1;
                }
            }
            Console.WriteLine($"Студенты в возрасте от {starAge} до {endAge} по курсам");
            for (int i = 1; i <= 6; i++)
            {
                Console.WriteLine(i + " курс " + onCource[i]+ " чел");
            }

        }
        public static void Task3()
        {
            //Создаем список студентов
            List<Student> list = new List<Student>();
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("students_4.csv");
            //File.ReadAllLines("students_4.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    //Добавляем в список новый экземляр класса Student
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), Convert.ToInt32(s[6]), int.Parse(s[7]), s[8]));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            sr.Close();
            list.Sort(new Comparison<Student>(Comparer));
            Console.WriteLine("Всего студентов:" + list.Count);
            Console.WriteLine("Кол-во студентов старше 18 - {0}", CountStudents(list, IsAgeBigger18));
            Console.WriteLine("Кол-во магистров - {0}", CountStudents(list, IsMagistr));
            Console.WriteLine("Кол-во бакалавров - {0}", CountStudents(list, IsBakalavr));
            Console.WriteLine("Количество студентов 5-6 курсов - {0}", CountStudents(list, 5, IsCourse)+ CountStudents(list, 6, IsCourse));
            Console.WriteLine(DateTime.Now - dt);
            list.Sort(new Comparison<Student>(ComparerCourseAndAge));
            //foreach(Student a in list)
            //{
            //    Console.WriteLine(a);
            //}
            CountAgesOnCourses(list, 18, 20);
        }
    }
}
