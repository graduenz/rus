using System.Linq.Expressions;
using Rus.Base.Application.Interfaces;

namespace Rus.Base.Infrastructure.Adapters;

public class FilterAdapter : IFilterAdapter
{
    public IQueryable<TEntity> ApplyFilterExpressions<TEntity>(IQueryable<TEntity> queryable,
        ICollection<Expression<Func<TEntity, bool>>>? filters)
    {
        if (filters == null || filters.Count == 0)
            return queryable;

        return filters.Aggregate(queryable, (current, filter) => current.Where(filter));
    }
}