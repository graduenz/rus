using System.Linq.Expressions;

namespace Rus.Base.Application.Interfaces;

public interface IFilterAdapter
{
    IQueryable<TEntity> ApplyFilterExpressions<TEntity>(IQueryable<TEntity> queryable,
        ICollection<Expression<Func<TEntity, bool>>>? filters);
}