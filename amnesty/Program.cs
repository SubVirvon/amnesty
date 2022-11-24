using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amnesty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();

            controller.Work();
        }
    }

    class Controller
    {
        private List<Person> _database;

        public Controller()
        {
            _database = new List<Person>() { new Person("Игорь", "антиправительственное"), new Person("Глеб", "разбой"), new Person("Степан", "антиправительственное"), new Person("Игорь", "мошенничество") };
        }

        public void Work()
        {
            ShowDatabase(_database);
            Console.WriteLine();

            var amnestyDatabase = _database.Where(person => person.Crime != "антиправительственное").ToList();
            _database = amnestyDatabase;

            ShowDatabase(_database);
            Console.ReadKey();
        }

        private void ShowDatabase (List<Person> database)
        {
            foreach(var person in database)
            {
                Console.WriteLine($"{person.Name}, преступление: {person.Crime}");
            }
        }
    }

    class Person
    {
        public string Name { get; private set; }
        public string Crime { get; private set; }

        public Person(string name, string crime)
        {
            Name = name;
            Crime = crime;
        }
    }
}
