using System;
using Demo.Optional;
using Demo.Optional.Linq;

namespace Demo
{
    public abstract class Person
    {
        public abstract string FullName { get; }
        public static Option<Person> TryCreate(string? firstName, string? middleNames, string? lastName) =>
            from first in firstName.NonWhiteSpace()
            from middle in middleNames.Optional(string.Empty)
            from last in lastName.NonWhiteSpace()
            select new CommonPerson(first, middle, last) as Person;

        public static Option<Person> TryCreate(string? name) =>
            name.NonWhiteSpace().Map<Person>(valid => new Philosopher(valid));
    }

    public class Philosopher : Person
    {
        public string Name { get; }
        public override string FullName => Name;

        public Philosopher(string? name)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }

    public class CommonPerson : Person
    {
        public string FirstName { get; }
        public string MiddleNames { get; }
        public string LastName { get; }

        public override string FullName => $"{this.FirstName} {this.LastName}";

        public CommonPerson(string firstName, string? middleNames, string lastName)
        {
            this.FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            this.MiddleNames = middleNames ?? string.Empty;
            this.LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }
    }
}
