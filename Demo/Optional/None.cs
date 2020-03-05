using System;

namespace Demo.Optional
{
    public class None<T> : Option<T>
    {
        public override Option<T1> Map<T1>(Func<T, T1> map) => new None<T1>();

        public override Option<T1> MapOptional<T1>(Func<T, Option<T1>> map) => new None<T1>();

        public override Option<T> Filter(Func<T, bool> predicate) => this;

        public override void Do(Action<T> action) { }

        public override T Reduce(T whenNone) => whenNone;

        public override T Reduce(Func<T> whenNone) => whenNone();

        public override string ToString() => "None";
    }

    public class None
    {
        private None() { }
        public static None Value { get; } = new None();
    }
}