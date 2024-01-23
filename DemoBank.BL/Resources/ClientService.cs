using DemoBank.BL.Interfaces;
using DemoBank.DAL.Interfaces;
using DemoBank.Models.Models;


namespace DemoBank.BL.Resources;

    public class ClientService
    {
        public class ClientsService : IServices<ClientDto>
        {
            private readonly IDataAccess<ClientDto> _ClientDataAccess;

            public ClientsService(IDataAccess<ClientDto> ClientDataAccess)
            {
                _ClientDataAccess = ClientDataAccess;

            }
            public async Task<ClientDto> CreateAsync(ClientDto entity)
            {
                ClientDto ClientDtoCreated = await _ClientDataAccess.CreateAsync(entity);

                return ClientDtoCreated;
            }

            public async Task<ClientDto> DeleteAsync(Guid id)
            {
                ClientDto ClientDtos = await _ClientDataAccess.DeleteAsync(id);

                return ClientDtos;
            }

            public async Task<IEnumerable<ClientDto>> GetAsync()
            {
                IEnumerable<ClientDto> ClientDtos = await _ClientDataAccess.GetAsync();

                return ClientDtos;
            }

            public async Task<ClientDto> GetAsync(Guid id)
            {
                ClientDto ClientDtoFound = await _ClientDataAccess.GetAsync(id);

                return ClientDtoFound;
            }

            public async Task<ClientDto> UpdateAsync(Guid id, ClientDto entity)
            {
                ClientDto ClientDtoUpdated = await _ClientDataAccess.UpdateAsync(id, entity);

                return ClientDtoUpdated;
            }
        }
    }
