namespace Troikatorz.Speech.Builders
{
    public abstract class Builder<T>
    {
        public abstract T Build();

        public static implicit operator T(Builder<T> builder) => builder.Build();
    }
}
