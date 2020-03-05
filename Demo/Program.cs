using System;
using System.Linq;
using Demo.Optional.Linq;

namespace Demo
{
    class Program
    {
        static void Display(Person person)
        {
            string line = "+" + new string('-', person.FullName.Length + 4) + "+";
            Console.WriteLine();
            Console.WriteLine(line);
            Console.WriteLine($"|  {person.FullName}  |");
            Console.WriteLine(line);
        }

        static void Main(string[] args)
        {
            try
            {
                new []
                {
                    Person.TryCreate("Edsger", "Wybe", null),
                    Person.TryCreate("Grace", "M.", "Hopper"),
                    Person.TryCreate("Aristoteles"),
                    Person.TryCreate(null)
                }
                .Do(x => { });

                Person.TryCreate(null, "Wybe", "Dijkstra").Do(Display);
                Person.TryCreate("Grace", "M.", "Hopper").Do(Display);
                Person.TryCreate(null).Do(Display);
                Person.TryCreate("Eratosthenes").Do(Display);
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine($"{e.Message}");
            }
            Console.ReadLine();
        }
    }
}
