

using AutoMapper;
using DemoBank.DAL.Database.DBModels;
using DemoBank.Models.Models;

namespace DemoBank.DAL.AutoMapper
{
    public class AccountOpeningProfile : Profile
    {
        public AccountOpeningProfile()
        {

            CreateMap<AccountOpeningDto, AccountOpening>();
            CreateMap<AccountOpening, AccountOpeningDto>();
            CreateMap<AccountOpeningCreateDto, AccountOpeningDto>()
            .ForMember(dest => dest.AccountId, opt => opt.Ignore()) // Ignorar la asignación directa de AccountOpeningId
            .AfterMap((src, dest) => dest.AccountId = Guid.NewGuid());
        } 
    }
}
