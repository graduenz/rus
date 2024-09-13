using System.Linq.Expressions;
using Rus.Base.Domain;

namespace Rus.Base.Application.Models;

public abstract class BaseSearch<TEntity> where TEntity : BaseEntity
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 100;
    public string? Sort { get; set; }
    public string? Order { get; set; }
    public string? Search { get; set; }
    public ICollection<Guid>? Ids { get; set; }

    public IEnumerable<Expression<Func<TEntity, bool>>> GetFilters()
    {
        if (Ids?.Count > 0)
            yield return e => Ids.Contains(e.Id);
        
        foreach (var filter in GetEntitySpecificFilters())
            yield return filter;
    }

    protected abstract IEnumerable<Expression<Func<TEntity, bool>>> GetEntitySpecificFilters();
}