using AutoMapper;
using Rus.Base.Application.Commands;
using Rus.Base.Application.Interfaces;
using Rus.Base.Application.Queries;

namespace Advertiser.Application.Advertiser;

public class CreateAdvertiserCommand : BaseCreateCommand<AdvertiserDto>
{
}

public class CreateAdvertiserCommandHandler : BaseCreateCommandHandler<CreateAdvertiserCommand, AdvertiserDto, Domain.Advertiser>
{
    public CreateAdvertiserCommandHandler(IBaseDbContext dbContext, IMapper mapper, ICurrentUserService currentUserService)
        : base(dbContext, mapper, currentUserService)
    {
    }
}

public class UpdateAdvertiserCommand : BaseUpdateCommand<AdvertiserDto>
{
}

public class UpdateAdvertiserCommandHandler : BaseUpdateCommandHandler<UpdateAdvertiserCommand, AdvertiserDto, Domain.Advertiser>
{
    public UpdateAdvertiserCommandHandler(IBaseDbContext dbContext, IMapper mapper, ICurrentUserService currentUserService)
        : base(dbContext, mapper, currentUserService)
    {
    }
}

public class DeleteAdvertiserCommand : BaseDeleteCommand<AdvertiserDto>
{
}

public class DeleteAdvertiserCommandHandler : BaseDeleteCommandHandler<DeleteAdvertiserCommand, AdvertiserDto, Domain.Advertiser>
{
    public DeleteAdvertiserCommandHandler(IBaseDbContext dbContext, IMapper mapper, ICurrentUserService currentUserService)
        : base(dbContext, mapper, currentUserService)
    {
    }
}

public class GetAdvertiserByIdQuery : BaseGetByIdQuery<AdvertiserDto>
{
}

public class GetAdvertiserByIdQueryHandler : BaseGetByIdQueryHandler<GetAdvertiserByIdQuery, AdvertiserDto, Domain.Advertiser>
{
    public GetAdvertiserByIdQueryHandler(IBaseDbContext dbContext, IMapper mapper, ICurrentUserService currentUserService) :
        base(dbContext, mapper, currentUserService)
    {
    }
}

public class GetAdvertiserListQuery : BaseGetListQuery<AdvertiserDto, Domain.Advertiser>
{
}

public class GetAdvertiserListQueryHandler : BaseGetListQueryHandler<GetAdvertiserListQuery, AdvertiserDto, Domain.Advertiser>
{
    public GetAdvertiserListQueryHandler(IBaseDbContext dbContext, IMapper mapper, IFilterAdapter filterAdapter,
        ISortAdapter sortAdapter, ICurrentUserService currentUserService) : base(dbContext, mapper, filterAdapter,
        sortAdapter, currentUserService)
    {
    }
}