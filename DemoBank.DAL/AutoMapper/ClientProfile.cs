using AutoMapper;
using DemoBank.DAL.Database.DBModels;
using DemoBank.Models.Models;

namespace DemoBank.DAL.AutoMapper
{
    public class ClientProfile : Profile
    {

        public ClientProfile()
        {
            CreateMap<ClientDto, Client>();
            CreateMap<Client, ClientDto>();
            CreateMap<ClientCreateDto, ClientDto>()
            .ForMember(dest => dest.ClientId, opt => opt.Ignore()) // Ignorar la asignación directa de ClientId
            .AfterMap((src, dest) => dest.ClientId = Guid.NewGuid()); 
        }
    }
}
