using DemoBank.BL.Interfaces;
using DemoBank.DAL.Interfaces;
using DemoBank.Models.Models;


namespace DemoBank.BL.Resources
{
    public class AccountOpeningService : IServices<AccountOpeningDto>
    {

        private readonly IDataAccess<AccountOpeningDto> _AccountOpeningDataAccess;

        public AccountOpeningService(IDataAccess<AccountOpeningDto> AccountOpeningDataAccess)
        {
            _AccountOpeningDataAccess = AccountOpeningDataAccess;

        }
        public async Task<AccountOpeningDto> CreateAsync(AccountOpeningDto entity)
        {
            AccountOpeningDto AccountOpeningDtoCreated = await _AccountOpeningDataAccess.CreateAsync(entity);

            return AccountOpeningDtoCreated;
        }

        public async Task<AccountOpeningDto> DeleteAsync(Guid id)
        {
            AccountOpeningDto AccountOpeningDtos = await _AccountOpeningDataAccess.DeleteAsync(id);

            return AccountOpeningDtos;
        }

        public async Task<IEnumerable<AccountOpeningDto>> GetAsync()
        {
            IEnumerable<AccountOpeningDto> AccountOpeningDtos = await _AccountOpeningDataAccess.GetAsync();

            return AccountOpeningDtos;
        }

        public async Task<AccountOpeningDto> GetAsync(Guid id)
        {
            AccountOpeningDto AccountOpeningDtoFound = await _AccountOpeningDataAccess.GetAsync(id);

            return AccountOpeningDtoFound;
        }

        public async Task<AccountOpeningDto> UpdateAsync(Guid id, AccountOpeningDto entity)
        {
            AccountOpeningDto AccountOpeningDtoUpdated = await _AccountOpeningDataAccess.UpdateAsync(id, entity);

            return AccountOpeningDtoUpdated;
        }
    }
}
