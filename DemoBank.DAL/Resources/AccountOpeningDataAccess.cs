using AutoMapper;
using DemoBank.DAL.Database.DBModels;
using DemoBank.DAL.Database;
using DemoBank.Models.Models;
using DemoBank.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DemoBank.DAL.Resources
{
    public class AccountOpeningDataAccess: IDataAccess<AccountOpeningDto>
    {
        private ProjectContext _projectContext;
        private IMapper _mapper;
        public AccountOpeningDataAccess(ProjectContext projectContext, IMapper mapper)
        {
            _projectContext = projectContext;
            _mapper = mapper;
        }
        public async Task<AccountOpeningDto> CreateAsync(AccountOpeningDto AccountOpening)
        {
            AccountOpening AccountOpeningToCreated = _mapper.Map<AccountOpening>(AccountOpening);

            await _projectContext.AccountOpening.AddAsync(AccountOpeningToCreated);
            await _projectContext.SaveChangesAsync();
            return AccountOpening;
        }

        public async Task<AccountOpeningDto> DeleteAsync(Guid id)
        {
            AccountOpening? AccountOpeningToDelete = await _projectContext.AccountOpening
                .FirstOrDefaultAsync(c => c.AccountId == id);

            if (AccountOpeningToDelete is null)
            {
                return null; // El AccountOpeninge no fue encontrado
            }

            _projectContext.AccountOpening.Remove(AccountOpeningToDelete);
            await _projectContext.SaveChangesAsync();

            AccountOpeningDto AccountOpeningDto = _mapper.Map<AccountOpeningDto>(AccountOpeningToDelete);
            return AccountOpeningDto;
        }

        public async Task<IEnumerable<AccountOpeningDto>> GetAsync()
        {
            IEnumerable<AccountOpening> AccountOpenings = await _projectContext.AccountOpening.ToListAsync();



            var AccountOpeningsDto = AccountOpenings.Select(AccountOpening => _mapper.Map<AccountOpeningDto>(AccountOpening));
            return AccountOpeningsDto;
        }

        public async Task<AccountOpeningDto> GetAsync(Guid id)
        {
            AccountOpening? AccountOpeningFounded = await _projectContext.AccountOpening
                .FirstOrDefaultAsync(c => c.AccountId == id);

            if (AccountOpeningFounded is null)
            {
                return null;
            }

            AccountOpeningDto AccountOpeningDto = _mapper.Map<AccountOpeningDto>(AccountOpeningFounded);

            return AccountOpeningDto;
        }

        public async Task<AccountOpeningDto?> UpdateAsync(Guid id, AccountOpeningDto entity)
        {
            AccountOpening? AccountOpeningToUpdate = await _projectContext.AccountOpening
                .FirstOrDefaultAsync(c => c.AccountId == id);

            if (AccountOpeningToUpdate is null)
            {
                return null;
            }

            AccountOpeningToUpdate.ProductType = entity.ProductType;
            AccountOpeningToUpdate.AccountNumber = entity.AccountNumber;
            AccountOpeningToUpdate.Currency = entity.Currency;
            AccountOpeningToUpdate.Amount = entity.Amount;
            AccountOpeningToUpdate.CreationDate = entity.CreationDate;
            AccountOpeningToUpdate.Branch = entity.Branch;
            AccountOpeningToUpdate.ClientId = entity.ClientId;

            await _projectContext.SaveChangesAsync();

            AccountOpeningDto AccountOpeningDto = _mapper.Map<AccountOpeningDto>(AccountOpeningToUpdate);

            return AccountOpeningDto;
        }
    }
}
