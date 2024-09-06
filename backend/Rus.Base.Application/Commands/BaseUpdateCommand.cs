using MediatR;
using Rus.Base.Application.Models;

namespace Rus.Base.Application.Commands;

public abstract class BaseUpdateCommand<TDto> : IRequest<ServiceResult<TDto>>
    where TDto : class
{
    public Guid Id { get; set; }
    
#pragma warning disable CS8618
    public TDto Model { get; set; }
#pragma warning restore CS8618
}