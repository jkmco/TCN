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
            CreateMap<Transaction, TransactionResource>();

            // API Resource to Domain
            CreateMap<TransactionResource, Transaction>()
                .ForMember(t => t.Id, opt => opt.Ignore());
            
        }
    }
}