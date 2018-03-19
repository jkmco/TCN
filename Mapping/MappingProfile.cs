using AutoMapper;
using TCN.Controllers.Resources;
using TCN.Models;

namespace TCN.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<User, UserResource>();
            CreateMap<Trade, SaveTradeResource>();
            CreateMap<Trade, LoadTradeResource>();            
            CreateMap<TradeCoin, KeyValuePairResource>();
            CreateMap<TradeFx, KeyValuePairResource>();
            CreateMap<Photo, PhotoResource>();

            // API Resource to Domain
            CreateMap<TradeQueryResource, TradeQuery>();
            CreateMap<SaveTradeResource, Trade>()
                .ForMember(t => t.Id, opt => opt.Ignore());
            
        }
    }
}