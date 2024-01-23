using AutoMapper;
using DemoBank.DAL.Database.DBModels;
using DemoBank.DAL.Database;
using DemoBank.Models.Models;
using Microsoft.EntityFrameworkCore;
using DemoBank.DAL.Interfaces;

namespace DemoBank.DAL.Resources
{
    public class ClientDataAccess: IDataAccess<ClientDto>
    {
        private ProjectContext _projectContext;
        private IMapper _mapper;
        public ClientDataAccess(ProjectContext projectContext, IMapper mapper)
        {
            _projectContext = projectContext;
            _mapper = mapper;
        }
        public async Task<ClientDto> CreateAsync(ClientDto client)
        {
            Client ClientToCreated = _mapper.Map<Client>(client);

            await _projectContext.Client.AddAsync(ClientToCreated);
            await _projectContext.SaveChangesAsync();

            return client;

        }

        public async Task<ClientDto> DeleteAsync(Guid id)
        {
            Client? clientToDelete = await _projectContext.Client
                .FirstOrDefaultAsync(c => c.ClientId == id);

            if (clientToDelete is null)
            {
                return null; // El cliente no fue encontrado
            }

            _projectContext.Client.Remove(clientToDelete);
            await _projectContext.SaveChangesAsync();

            ClientDto clientDto = _mapper.Map<ClientDto>(clientToDelete);

            return clientDto;
        }

        public async Task<IEnumerable<ClientDto>> GetAsync()
        {
            IEnumerable<Client> clients = await _projectContext.Client.ToListAsync();

            

            var ClientsDto = clients.Select(client => _mapper.Map<ClientDto>(client));

            return ClientsDto;
        }

        public async Task<ClientDto> GetAsync(Guid id)
        {
            Client? ClientFounded = await _projectContext.Client
                .FirstOrDefaultAsync(c => c.ClientId == id);

            if (ClientFounded is null)
            {
                return null;
            }

            ClientDto ClientDto = _mapper.Map<ClientDto>(ClientFounded);

            return ClientDto;
        }

        public async Task<ClientDto?> UpdateAsync(Guid id, ClientDto entity)
        {
            Client? clientToUpdate = await _projectContext.Client
                .FirstOrDefaultAsync(c => c.ClientId == id);

            if (clientToUpdate is null)
            {
                return null;
            }

            clientToUpdate.FirstName = entity.FirstName;
            clientToUpdate.LastName = entity.LastName;
            clientToUpdate.MiddleName = entity.MiddleName;
            clientToUpdate.DocumentType = entity.DocumentType;
            clientToUpdate.IdentityDocument = entity.IdentityDocument;
            clientToUpdate.BirthDate = entity.BirthDate;
            clientToUpdate.Gender = entity.Gender;

        
            await _projectContext.SaveChangesAsync();

            ClientDto ClientDto = _mapper.Map<ClientDto>(clientToUpdate);

            return ClientDto;
        }
    }
}
