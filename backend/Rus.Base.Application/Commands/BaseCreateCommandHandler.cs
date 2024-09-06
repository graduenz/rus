using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using MediatR;
using Rus.Base.Application.Interfaces;
using Rus.Base.Application.Models;
using Rus.Base.Domain;

namespace Rus.Base.Application.Commands;

[SuppressMessage("SonarLint", "S2436", Justification = "Abstraction tradeoffs")]
public abstract class BaseCreateCommandHandler<TCommand, TDto, TEntity> : IRequestHandler<TCommand, ServiceResult<TDto>>
    where TCommand : BaseCreateCommand<TDto>
    where TDto : class
    where TEntity : BaseEntity
{
    public IBaseDbContext DbContext { get; }
    public IMapper Mapper { get; }
    public ICurrentUserService CurrentUserService { get; }

    protected BaseCreateCommandHandler(IBaseDbContext dbContext, IMapper mapper, ICurrentUserService currentUserService)
    {
        DbContext = dbContext;
        Mapper = mapper;
        CurrentUserService = currentUserService;
    }

    public virtual async Task<ServiceResult<TDto>> Handle(TCommand request, CancellationToken cancellationToken)
    {
        var userId = CurrentUserService.GetCurrentUserUniqueId();

        // ReSharper disable once HeapView.PossibleBoxingAllocation
        var entity = Mapper.Map<TEntity>(request.Model);

        await BeforeAddAsync(entity, userId, cancellationToken);

        await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);

        var dto = Mapper.Map<TDto>(entity);
        return ServiceResult.Success(dto);
    }

    protected virtual Task BeforeAddAsync(TEntity entity, string userId, CancellationToken cancellationToken)
    {
        entity.CreatedAt = entity.ModifiedAt = DateTime.UtcNow;
        entity.CreatedBy = entity.ModifiedBy = userId;

        return Task.CompletedTask;
    }
}