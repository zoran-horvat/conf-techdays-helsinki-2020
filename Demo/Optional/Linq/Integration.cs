using System;

namespace Demo.Optional.Linq
{
    public static class Integration
    {
        public static Option<TResult> Select<T, TResult>(this Option<T> optional, Func<T, TResult> map) =>
            optional.Map(map);

        public static Option<T> Where<T>(this Option<T> optional, Func<T, bool> predicate) =>
            optional.Filter(predicate);

        public static Option<TResult> SelectMany<T, T1, TResult>(this Option<T> optional,
            Func<T, Option<T1>> map, Func<T, T1, TResult> reduce) =>
            optional.MapOptional(content => map(content).Map(result => reduce(content, result)));
    }
}
