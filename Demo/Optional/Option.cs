using System;

namespace Demo.Optional
{
    public abstract class Option<T>
    {
        public abstract Option<T1> Map<T1>(Func<T, T1> map);
        public abstract Option<T1> MapOptional<T1>(Func<T, Option<T1>> map);
        public abstract Option<T> Filter(Func<T, bool> predicate);
        public abstract void Do(Action<T> action);
        public abstract T Reduce(T whenNone);
        public abstract T Reduce(Func<T> whenNone);

        public static implicit operator Option<T>(T content) => 
            new Some<T>(content);

        public static implicit operator Option<T>(None none) =>
            new None<T>();
    }

    public static class Option
    {
        public static Option<T> Of<T>(T value) => new Some<T>(value);
        public static Option<T> None<T>() => new None<T>();
    }
}
