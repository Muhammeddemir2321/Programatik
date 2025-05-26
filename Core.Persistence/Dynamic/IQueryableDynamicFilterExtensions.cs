using System.Text;
using System.Linq.Dynamic.Core;

namespace Core.Persistence.Dynamic;

public static class IQueryableDynamicFilterExtensions
{
    private static readonly IDictionary<string, string>
        Operators = new Dictionary<string, string>
        {
            { "empty", "=" },
            { "notempty", "!=" },
            { "eq", "=" },
            { "lt", "<" },
            { "lte", "<=" },
            { "gt", ">" },
            { "gte", ">=" },
            { "isnull", "== null" },
            { "isnotnull", "!= null" },
            { "startswith", "StartsWith" },
            { "endswith", "EndsWith" },
            { "contains", "Contains" },
            { "doesnotcontain", "Contains" }
        };

    public static IQueryable<T> ToDynamic<T>(this IQueryable<T> query, Dynamic dynamic)
    {
        if (dynamic.Filter is not null && dynamic.Filter.Filters is not null) query = Filter(query, dynamic.Filter);
        if (dynamic.Sort is not null && dynamic.Sort.Any()) query = Sort(query, dynamic.Sort);
        return query;
    }
    private static IQueryable<T> Sort<T>(IQueryable<T> queryable, IEnumerable<Sort> sort)
    {
        if (sort.Any())
        {
            string ordering = string.Join(",", sort.Select(s => $"{s.Field} {s.Dir}"));
            return queryable.OrderBy(ordering);
        }

        return queryable;
    }

    private static IQueryable<T> Filter<T>(IQueryable<T> queryable, Filter filter)
    {
        IList<Filter> filters = GetAllFilters(filter);
        string?[] values = filters.Select(f => f.Value).ToArray();
        string where = Transform(filter, filters);
        queryable = queryable.Where(where, values);

        return queryable;
    }


    public static IList<Filter> GetAllFilters(Filter filter)
    {
        List<Filter> filters = new() { filter };

        if (filter.Filters is not null && filter.Filters.Any())
        {
            foreach (var child in filter.Filters)
                filters.AddRange(GetAllFilters(child));
        }

        return filters;
    }


    public static string Transform(Filter filter, IList<Filter> filters)
    {
        int index = filters.IndexOf(filter);
        StringBuilder where = new();

        if (string.IsNullOrWhiteSpace(filter.Operator) || !Operators.TryGetValue(filter.Operator, out string? comparison))
        {
            if (filter.Filters is not null && filter.Filters.Any() && filter.Logic is not null)
            {
                var inner = string.Join($" {filter.Logic} ", filter.Filters.Select(f => Transform(f, filters)));
                return $"({inner})";
            }
            return string.Empty;
        }
        if (!string.IsNullOrEmpty(filter.Value))
        {
            if (comparison == "doesnotcontain")
                where.Append($"(!np({filter.Field}).{comparison}(@{index}))");
            else if (comparison == "StartsWith" ||
                     comparison == "EndsWith" ||
                     comparison == "Contains")
                where.Append($"(np({filter.Field}).{comparison}(@{index}))");
            else
                where.Append($"np({filter.Field}) {comparison} @{index}");
        }
        else if (comparison == "isnull" || comparison == "isnotnull")
        {
            where.Append($"np({filter.Field}) {comparison}");
        }
        else if (comparison == "empty" || comparison == "notempty")
        {
            where.Append($"np({filter.Field}) {comparison} \"\"");
        }

        return where.ToString();
    }
}
