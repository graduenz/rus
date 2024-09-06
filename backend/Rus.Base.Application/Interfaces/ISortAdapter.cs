using Rus.Base.Application.Models;

namespace Rus.Base.Application.Interfaces;

public interface ISortAdapter
{
    IQueryable<TEntity> ApplySortExpressions<TEntity>(IQueryable<TEntity> queryable, ICollection<SortExpression>? sortExpressions);
}