namespace Troikatorz.Speech.Core
{
    public interface IMapper<TSource, TDestination>
    {
        TDestination Map(TSource source);
    }
}
