using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rus.Base.Application.Interfaces;
using Rus.Base.Application.Models;
using Rus.Base.Domain;

namespace Rus.Base.Application.Commands;

[SuppressMessage("SonarLint", "S2436", Justification = "Abstraction tradeoffs")]
public abstract class BaseDeleteCommandHandler<TCommand, TDto, TEntity> : IRequestHandler<TCommand, ServiceResult<TDto>>
    where TCommand : BaseDeleteCommand<TDto>
    where TDto : class
    where TEntity : BaseEntity
{
    public IBaseDbContext DbContext { get; }
    public IMapper Mapper { get; }
    public ICurrentUserService CurrentUserService { get; }

    protected BaseDeleteCommandHandler(IBaseDbContext dbContext, IMapper mapper, ICurrentUserService currentUserService)
    {
        DbContext = dbContext;
        Mapper = mapper;
        CurrentUserService = currentUserService;
    }

    public async Task<ServiceResult<TDto>> Handle(TCommand request, CancellationToken cancellationToken)
    {
        var userId = CurrentUserService.GetCurrentUserIdentifier();

        // ReSharper disable once HeapView.BoxingAllocation
        var entity = await GetEntityAsync(request, userId, cancellationToken);

        if (entity == null)
            return ServiceResult.Failed<TDto>(ServiceError.NotFound);

        await BeforeDeleteAsync(request, userId, cancellationToken);

        DbContext.Set<TEntity>().Remove(entity);
        await DbContext.SaveChangesAsync(cancellationToken);

        var dto = Mapper.Map<TDto>(entity);
        return ServiceResult.Success(dto);
    }

    protected virtual Task BeforeDeleteAsync(TCommand request, string userId, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    protected virtual async Task<TEntity?> GetEntityAsync(TCommand request, string userId,
        CancellationToken cancellationToken)
    {
        return await DbContext.Set<TEntity>().FirstOrDefaultAsync(
            m => m.Id == request.Id,
            cancellationToken);
    }
}