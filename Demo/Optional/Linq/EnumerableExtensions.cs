using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Optional.Linq
{
    public static class EnumerableExtensions
    {
        public static void Do<T>(this IEnumerable<Option<T>> sequence, Action<T> action)
        {
            foreach (T item in sequence.Flatten())
            {
                action(item);
            }
        }

        public static IEnumerable<T> Flatten<T>(this IEnumerable<Option<T>> sequence) =>
            sequence.OfType<Some<T>>().Select(some => some.Content);

        public static IEnumerable<T1> Select<T, T1>(this IEnumerable<Option<T>> sequence, Func<T, T1> map) =>
            sequence.Flatten().Select(map);

        public static IEnumerable<T> Where<T>(this IEnumerable<Option<T>> sequence, Func<T, bool> predicate) =>
            sequence.Flatten().Where(predicate);
    }
}
