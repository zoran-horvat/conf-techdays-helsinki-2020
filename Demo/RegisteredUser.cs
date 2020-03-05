using System;
using Demo.Optional;
using Demo.Optional.Linq;

namespace Demo
{
    class RegisteredUser
    {
        private string UserName { get; }
        private Person Person { get; }

        private RegisteredUser(string userName, Person person)
        {
            this.UserName = userName;
            this.Person = person;
        }

        public static Option<RegisteredUser> TryCreate(string? userName, Person? person) =>
            from user in userName.NonWhiteSpace()
            from p in person.NonNull()
            select new RegisteredUser(user, p);
    }
}