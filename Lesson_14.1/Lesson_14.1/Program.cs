using System.Security.Cryptography;

namespace Lesson_14._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] people = { "Анна", "Мария", "Сергей", "Алексей", "Дмитрий", "Ян" };

            //var selectedPeople = from p in people // промежуточная переменная p 
            //                     where p.StartsWith("А") // фильтрация по условию
            //                     orderby p // сортировка по возрастанию (дефолтная)
            //                     select p; // выбираем объект и сохраняем в выборку
            var selectedPeople = people.Where(p => p.StartsWith("А")).OrderBy(p => p);

            foreach (string s in selectedPeople)
                Console.WriteLine(s);

            var objects = new List<object>()
            {
               1,
               "Сергей ",
               "Андрей ",
               300,
            };
            var selectobj = objects.Where(p => p is string).OrderBy(p => p);
            foreach (var obj in selectobj)
                Console.WriteLine(obj);

            // Добавим Россию с её городами
            var russianCities = new List<City>();
            russianCities.Add(new City("Москва", 11900000));
            russianCities.Add(new City("Санкт-Петербург", 4991000));
            russianCities.Add(new City("Волгоград", 1099000));
            russianCities.Add(new City("Казань", 1169000));
            russianCities.Add(new City("Севастополь", 449138));

            foreach (var city in russianCities.Where(c => c.Name.Length <= 10).OrderByDescending(c => c.Name.Length)) 
                Console.WriteLine(city.Name);

            string[] text = { "Раз два три",
                               "четыре пять шесть",
                               "семь восемь девять" };
            var words = from str in text
                        from word in str.Split(" ")
                        select word;
            foreach (var word in words)
                Console.WriteLine(word);

            //Сделайте выборку всех чисел в новую коллекцию, расположив их в ней по возрастанию.
            var numsList = new List<int[]>()
                {
                   new[] {2, 3, 7, 1},
                   new[] {45, 17, 88, 0},
                   new[] {23, 32, 44, -6},
                };
            //var newList = from p in numsList
            //              from n in p
            //              orderby n
            //              select n;
            var newList = numsList
                   .SelectMany(s => s) // выбираем элементы
                   .OrderBy(s => s); // сортируем
            foreach (int n in newList)
                Console.WriteLine(n);
        }

        // Создадим модель класс для города
        public class City
        {
            public City(string name, long population)
            {
                Name = name;
                Population = population;
            }

            public string Name { get; set; }
            public long Population { get; set; }
        }
    }
}