using System.Collections.Concurrent;
using System.ComponentModel;
using System.Text;
using System.Text.Json;


namespace Lab015b
{
    public class MyLogger
    {
        public void Log(string component, string message)
        {
            Console.WriteLine("Component: {0} Message: {1} ", component, message);
        }
    }
    public class Person : IRepository<Person>
    {
        public string Name { get; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }


        public Person GetPerson(string name)
        {
            return new Person(name, Age);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    interface IRepository<T> : IDisposable
    where T : class
    {
        T GetPerson(string name); // получение одного человека по имени
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Person tom = new Person("Tom", 37);
            string json = JsonSerializer.Serialize(tom);
            Console.WriteLine(json);
            Person? restoredPerson = JsonSerializer.Deserialize<Person>(json);
            Console.WriteLine(restoredPerson?.Name); // Tom

            string path = @"somefile.txt";
            string path2 = @"somefile.json";

            File.WriteAllText(path, json);
            File.WriteAllText(path2, json);
        }
    }
}
