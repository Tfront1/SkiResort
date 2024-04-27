using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

namespace SkiResort.Presentation.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> ApplyFiltering<T>(this IQueryable<T> source, string filter)
    {
        if (string.IsNullOrWhiteSpace(filter))
        {
            return source;
        }

        var parameter = Expression.Parameter(typeof(T), "x");
        Expression combined = null;

        // Отримання всіх властивостей, які є строками
        var stringProperties = typeof(T).GetProperties()
            .Where(p => p.PropertyType == typeof(string));

        foreach (var prop in stringProperties)
        {
            var propAccess = Expression.MakeMemberAccess(parameter, prop);
            var toStringCall = Expression.Call(propAccess, prop.PropertyType.GetMethod("ToString", Type.EmptyTypes));
            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var containsCall = Expression.Call(toStringCall, containsMethod, Expression.Constant(filter, typeof(string)));

            combined = combined == null ? containsCall : Expression.OrElse(combined, containsCall);
        }

        if (combined == null)
        {
            return source;
        }

        var lambda = Expression.Lambda<Func<T, bool>>(combined, parameter);
        return source.Where(lambda);
    }

    public static IQueryable<T> ApplySorting<T>(this IQueryable<T> source, string sortBy, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
            return source;

        var direction = ascending ? "ascending" : "descending";
        source = source.OrderBy($"{sortBy} {direction}");
        return source;
    }

    public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> source, int pageIndex, int pageSize)
    {
        return source.Skip((pageIndex - 1) * pageSize).Take(pageSize);
    }
}