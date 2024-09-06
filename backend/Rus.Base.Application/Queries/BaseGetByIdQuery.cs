using MediatR;
using Rus.Base.Application.Models;

namespace Rus.Base.Application.Queries;

public abstract class BaseGetByIdQuery<TDto> : IRequest<ServiceResult<TDto>>
    where TDto : class
{
    public Guid Id { get; set; }
}