using Advertiser.Application.Advertiser;
using AutoMapper;

namespace Advertiser.Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Domain.Advertiser, AdvertiserDto>();
        CreateMap<AdvertiserDto, Domain.Advertiser>();
    }
}