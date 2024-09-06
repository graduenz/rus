using MediatR;
using Rus.Base.Application.Models;

namespace Rus.Base.Application.Commands;

public abstract class BaseCreateCommand<TDto> : IRequest<ServiceResult<TDto>>
    where TDto : class
{
#pragma warning disable CS8618
    public TDto Model { get; set; }
#pragma warning restore CS8618
}