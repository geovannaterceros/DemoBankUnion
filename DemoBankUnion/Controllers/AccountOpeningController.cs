using AutoMapper;
using DemoBank.BL.Interfaces;
using DemoBank.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoBankUnion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountOpeningController : ControllerBase
    {
        private readonly IServices<AccountOpeningDto> _AccountOpeningService;
        private readonly IMapper _mapper;

        public AccountOpeningController(IServices<AccountOpeningDto> AccountOpeningService, IMapper mapper)
        {
            _AccountOpeningService = AccountOpeningService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            AccountOpeningDto AccountOpeningDto = await _AccountOpeningService.GetAsync(id);
            if (AccountOpeningDto is not null)
            {
                return Ok(AccountOpeningDto);
            }

            return NotFound();
        }

        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {
            IEnumerable<AccountOpeningDto> AccountOpeningDtos = await _AccountOpeningService.GetAsync();
            if (AccountOpeningDtos is not null)
            {
                return Ok(AccountOpeningDtos);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AccountOpeningCreateDto AccountOpeningCreateDto)
        {

            AccountOpeningDto AccountOpeningDto = _mapper.Map<AccountOpeningDto>(AccountOpeningCreateDto);
            AccountOpeningDto AccountOpeningDtoCreated = await _AccountOpeningService.CreateAsync(AccountOpeningDto);

            if (AccountOpeningDtoCreated is not null)
            {
                return Created(nameof(CreateAsync), AccountOpeningDtoCreated);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] AccountOpeningDto AccountOpeningDto)
        {

            AccountOpeningDto AccountOpeningDtoUpdated = await _AccountOpeningService.UpdateAsync(id, AccountOpeningDto);

            if (AccountOpeningDtoUpdated is not null)
            {
                return Ok(AccountOpeningDtoUpdated);
            }
            return NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {

            AccountOpeningDto AccountOpeningDtoDelete = await _AccountOpeningService.DeleteAsync(id);

            if (AccountOpeningDtoDelete is not null)
            {
                return Ok(AccountOpeningDtoDelete);
            }
            return NotFound();
        }
    }
}
