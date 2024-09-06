using MediatR;
using Rus.Base.Application.Models;

namespace Rus.Base.Application.Commands;

public abstract class BaseDeleteCommand<TDto> : IRequest<ServiceResult<TDto>>
    where TDto : class
{
    public Guid Id { get; set; }
}