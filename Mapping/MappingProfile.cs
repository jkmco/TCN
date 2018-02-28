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
            CreateMap<Transaction, SaveTransactionResource>();
            CreateMap<Transaction, GetTransactionResource>();            
            CreateMap<TransactionCoin, KeyValuePairResource>();
            CreateMap<TransactionFx, KeyValuePairResource>();

            // API Resource to Domain
            CreateMap<SaveTransactionResource, Transaction>()
                .ForMember(t => t.Id, opt => opt.Ignore());
            
        }
    }
}