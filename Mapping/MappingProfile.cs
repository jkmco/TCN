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
            CreateMap<Transaction, CreateTransactionResource>();
            CreateMap<TransactionCoin, KeyValuePairResource>();
            CreateMap<TransactionFx, KeyValuePairResource>();

            // API Resource to Domain
            CreateMap<CreateTransactionResource, Transaction>()
                .ForMember(t => t.Id, opt => opt.Ignore());
            
        }
    }
}