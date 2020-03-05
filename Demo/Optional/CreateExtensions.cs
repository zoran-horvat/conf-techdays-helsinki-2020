namespace Demo.Optional
{
    public static class CreateExtensions
    {
        public static Option<T> NonNull<T>(this T? value) where T : class =>
            value is null ? (Option<T>)new None<T>() : new Some<T>(value);

        public static Option<string> NonWhiteSpace(this string? value) =>
            string.IsNullOrWhiteSpace(value) ? (Option<string>)new None<string>() : new Some<string>(value);

        public static Option<T> Optional<T>(this T? value, T whenNull) where T : class =>
            new Some<T>(value ?? whenNull);
    }
}
