using Microsoft.AspNetCore.Http;
using MongoDB.Driver;

namespace ecommerce_core.Helpers;

public class PaginationHelps
{
    public static FilterDefinition<T> Pagination<T>(IMongoCollection<T> collection, IQueryCollection query)
    {
        var builder = Builders<T>.Filter;
        var filters = new List<FilterDefinition<T>>();

        foreach (var key in query.Keys)
        {
            if (key.Equals("page", StringComparison.CurrentCultureIgnoreCase) || key.Equals("pageSize", StringComparison.CurrentCultureIgnoreCase))
                continue;

            // Para cada parâmetro, adiciona um filtro de igualdade
            var value = query[key].ToString();
            filters.Add(builder.Eq(key, value));
        }

        FilterDefinition<T> filter = filters.Count != 0 ? builder.And(filters) : builder.Empty;

        return filter;
    }
}
