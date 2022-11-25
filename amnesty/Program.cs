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
            Database dataBase = new Database(new List<Person>()
            {
                new Person("Игорь", Crime.антиправительственное),
                new Person("Глеб", Crime.разбой),
                new Person("Степан", Crime.антиправительственное),
                new Person("Игорь", Crime.мошенничество)
            });

            dataBase.ShowInfo();
            Console.WriteLine();
            dataBase.GiveAmnesty(Crime.антиправительственное);
            dataBase.ShowInfo();
            Console.ReadKey();
        }
    }

    class Person
    {
        public string Name { get; private set; }
        public Crime Crime { get; private set; }

        public Person(string name, Crime crime)
        {
            Name = name;
            Crime = crime;
        }
    }

    class Database
    {
        private List<Person> _persons;

        public Database(List<Person> database)
        {
            _persons = database;
        }

        public void GiveAmnesty(Crime crime)
        {
            _persons = _persons.Where(person => person.Crime != crime).ToList();
        }

        public void ShowInfo()
        {
            foreach (var person in _persons)
            {
                Console.WriteLine($"{person.Name}, преступление: {person.Crime}");
            }
        }
    }

    enum Crime
    {
        антиправительственное,
        разбой,
        мошенничество
    }
}
