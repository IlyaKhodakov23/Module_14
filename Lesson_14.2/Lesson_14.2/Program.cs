using System.Runtime.InteropServices;

namespace Lesson_14._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "Обезьяна", "Лягушка", "Кот", "Собака", "Черепаха" };
            var word = words.OrderBy(u => u.Length).Select(u => new { 
                Name = u,
                Length = u.Length});
            foreach (var word2 in word)
            {
                Console.WriteLine(word2.Name + " " + word2.Length);
            }

            // Наш список студентов
            List<Student> students = new List<Student>
            {
                   new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                   new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
                   new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
                   new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            //Задание 14.2.3
            //Выберите всех студентов моложе 27, сгенерируйте из них анкеты (модель класса расположена ниже).

            var youngStudents = from s in students
                                where s.Age < 27
                                let birthyear = DateTime.Now.Year - s.Age
                                select new Application()
                                {
                                    Name = s.Name,
                                    YearOfBirth = birthyear
                                };

            // Список курсов
            var coarses = new List<Course>
            {
               new Course {Name="Язык программирования C#", StartDate = new DateTime(2020, 12, 20)},
               new Course {Name="Язык SQL и реляционные базы данных", StartDate = new DateTime(2020, 12, 15)},
            };
            //Задание 14.2.4
            //Теперь добавьте всех студентов младше 29 лет, владеющих английским языком, в курс «Язык программирования C#». 
            var studentcourse = from s in students
                                where s.Age < 29 && s.Languages.Contains("английский")
                                let birthyear = DateTime.Now.Year - s.Age
                                from c in coarses
                                where c.Name.Contains("C#")
                                select new
                                {
                                    Name = s.Name,
                                    YearofBirth = birthyear,
                                    NameCourse = c.Name
                                };
            foreach (var stud in studentcourse)
            {
                Console.WriteLine($"Студент {stud.Name} ({stud.YearofBirth}) добавлен курс {stud.NameCourse}");
            }

            //Задание 14.2.5
            //Давайте попробуем сделать свою мини - программу для просмотра контактов с постраничным выводом.
            //Дан список: 
            var contacts = new List<Contact>()
            {
                new Contact() { Name = "Андрей", Phone = 7999945005 },
                new Contact() { Name = "Сергей", Phone = 799990455 },
                new Contact() { Name = "Иван", Phone = 79999675 },
                new Contact() { Name = "Игорь", Phone = 8884994 },
                new Contact() { Name = "Анна", Phone = 665565656 },
                new Contact() { Name = "Василий", Phone = 3434 }
            };
            //Сделайте вывод контактов в консоль по два в бесконечном цикле.
            //Выводить нужно постранично, например так: вы ввели 1 — показало Андрея и Сергея, 2 — Ивана и Игоря, 3 — Анну и Василия.
            while (true)
            {
                var keyChar = Console.ReadKey().KeyChar; // получаем символ с консоли
                Console.Clear();  //  очистка консоли от введенного текста
                                  //  переменная для хранения запроса в зависимости от введенного с консоли числа
                IEnumerable<Contact> page = null;

                switch (keyChar)
                {
                    case ('1'):
                        page = contacts.Take(2);
                        break;
                    case ('2'):
                        page = contacts.Skip(2).Take(2);
                        break;
                    case ('3'):
                        page = contacts.Skip(4).Take(2);
                        break;
                }

            }
        }

        public class Course
        {
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
        }

        public class Application
        {
            public string Name { get; set; }
            public int YearOfBirth { get; set; }
        }

        public class Student
        {
            public string Name { get; set; }
            public  int Age { get; set; }
            public List<string> Languages { get; set; }
        }

        public class Contact
        {
            public string Name { get; set; }
            public long Phone { get; set; }
        }
    }
}