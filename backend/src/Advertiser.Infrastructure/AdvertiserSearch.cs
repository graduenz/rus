using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Rus.Base.Application.Models;

namespace Advertiser.Infrastructure;

public class AdvertiserSearch : BaseSearch<Domain.Advertiser>
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    
    protected override IEnumerable<Expression<Func<Domain.Advertiser, bool>>> GetEntitySpecificFilters()
    {
        if (!string.IsNullOrEmpty(Search))
            yield return a => EF.Functions.ILike(a.Name!, Search);
        
        if (!string.IsNullOrEmpty(Name))
            yield return a => EF.Functions.ILike(a.Name!, Name);
        
        if (!string.IsNullOrEmpty(Email))
            yield return a => EF.Functions.ILike(a.Email!, Email);
        
        if (!string.IsNullOrEmpty(Phone))
            yield return a => EF.Functions.ILike(a.Phone!, Phone);
    }
}