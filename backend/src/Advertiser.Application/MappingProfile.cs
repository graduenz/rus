using AutoMapper;

namespace Advertiser.Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Advertiser.Domain.Advertiser, AdvertiserDto>();
        CreateMap<AdvertiserDto, Advertiser.Domain.Advertiser>();
    }
}