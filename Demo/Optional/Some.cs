using System;

namespace Demo.Optional
{
    public class Some<T> : Option<T>
    {
        public T Content { get; }

        public Some(T content)
        {
            this.Content = content;
        }

        public override Option<T1> Map<T1>(Func<T, T1> map) =>
            new Some<T1>(map(this.Content));

        public override Option<T1> MapOptional<T1>(Func<T, Option<T1>> map) =>
            map(this.Content);

        public override Option<T> Filter(Func<T, bool> predicate) =>
            predicate(this.Content) ? (Option<T>)this : new None<T>();

        public override void Do(Action<T> action) =>
            action(this.Content);

        public override T Reduce(T whenNone) =>
            this.Content;

        public override T Reduce(Func<T> whenNone) =>
            this.Content;

        public override string ToString() =>
            $"Some[{this.Content?.ToString() ?? "<null>"}]";
    }
}